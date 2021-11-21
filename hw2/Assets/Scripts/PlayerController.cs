using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float rotationSpeed;
	public float dashSpeed;
	public float dashDistance;
	public float dashCooldown;
	public AudioClip hurtClip;

	private Rigidbody rb;
	private GameObject mainCamera;
	private Vector3 mainCameraInitialRelativePosition;
	private SwordController swordController;
	private AudioSource audioSource;

	private bool isDashing;
	private Vector3 dashTarget;

	private bool hitWall;
	private float health;
	private Image healthBar;
	private int score;
	private Text scoreText;

	private GameOverController gameOverController;

	void Start()
	{
		rb = GetComponent<Rigidbody>();

		mainCamera = GameObject.Find("Main Camera");
		mainCameraInitialRelativePosition = mainCamera.transform.position - transform.position;

		swordController = gameObject.GetComponentInChildren<SwordController>();
		
		audioSource = gameObject.GetComponent<AudioSource>();

		health = 1.0f;
		healthBar = GameObject.Find("HealthFull").GetComponent<Image>();

		score = 0;
		scoreText = GameObject.Find("ScoreText").GetComponent<Text>();

		gameOverController = GameObject.Find("GameOverController").GetComponent<GameOverController>();
	}

	// Update is called once per frame
	void Update()
	{
		healthBar.fillAmount = health;
	}

	void FixedUpdate()
	{
		if (!swordController.IsSwinging())
		{
			if (!isDashing)
			{
				float horizontalInput = Input.GetAxis("Horizontal");
				float verticalInput = Input.GetAxis("Vertical");

				// Normal
				Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
				moveDirection.Normalize();

				transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

				/*
				if (moveDirection != Vector3.zero)
				{
					Quaternion rotation = Quaternion.LookRotation(moveDirection, Vector3.up);
					transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
				}
				*/

				Ray mouseRay = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
				Plane p = new Plane(Vector3.up, transform.position);
				if (p.Raycast(mouseRay, out float hitDist))
				{
					Vector3 hitPoint = mouseRay.GetPoint(hitDist);
					if (Vector3.Distance(transform.position, hitPoint) > 0.4)
					{
						Quaternion rotation = Quaternion.LookRotation(hitPoint - transform.position, Vector3.up);
						transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
					}
				}

				if (Input.GetKeyDown(KeyCode.Space))
				{
					isDashing = true;
					dashTarget = transform.position + transform.forward * dashDistance;
				}
			}
			else
			{
				// transform.Translate(transform.forward * dashSpeed * Time.deltaTime, Space.World);
				rb.MovePosition(Vector3.Lerp(transform.position, dashTarget, dashSpeed * Time.deltaTime));

				// Clear dashing state
				if (Vector3.Distance(transform.position, dashTarget) < 0.01f)
				{
					isDashing = false;
				}
			}
		}
	}

	void LateUpdate()
	{
		Vector3 mainCameraPosition = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, transform.position.z + mainCameraInitialRelativePosition.z);
		mainCamera.transform.position = mainCameraPosition;
	}

	void OnCollisionEnter(Collision collision)
	{
		// Debug.Log($"Player collision enter: {collision.transform.name}");

		if (collision.transform.parent != null && collision.transform.parent.CompareTag("Wall"))
		{
			isDashing = false;
		}
	}

	public bool IsDashing()
	{
		return isDashing;
	}

	public void GetHit(float damage)
	{
		health -= damage;
		if (health < 1e-6)
		{
			health = 0;
			gameOverController.EnableGameOver();
		}

		gameObject.GetComponentInChildren<ParticleSystem>().Play();
		audioSource.PlayOneShot(hurtClip);
	}

	public void AddScore() {
		score++;
		scoreText.text = $"SCORE: {score}";
	}
}
