using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;
	public float speed;
	public Animator animator;
	public GameController gameController;
	public AudioClip winClip;
	public AudioClip loseClip;
	public AudioClip bgmClip;

  private bool isGrounded;
  private Vector3 initialPosition;
	private bool active;
	private AudioSource audioSource;

	void Start()
	{
		rb = GetComponent<Rigidbody>();

    initialPosition = transform.position;

		active = true;

		audioSource = gameObject.GetComponent<AudioSource>();

		playClip(bgmClip);
	}

	// Update is called once per frame
	void Update()
	{
	}

	void FixedUpdate()
	{
		if (!active) return;

		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
		moveDirection.Normalize();

		transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

		if (moveDirection != Vector3.zero)
		{
			Quaternion rotation = Quaternion.LookRotation(moveDirection, Vector3.up);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 360 * Time.deltaTime);
		}

		if (isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
			rb.velocity += Vector3.up * 10.0f;
			isGrounded = false;
		}

		animator.SetFloat("speed", moveDirection.magnitude);
    animator.SetBool("isJump", !isGrounded);
	}

  void OnCollisionEnter(Collision o) {
    if (o.transform.name == "Plane") {
      isGrounded = true;
    }

    if (o.transform.name == "Enemy") {
			playClip(loseClip);
			gameController.Lose();
    }

		if (o.transform.name == "WinCube") {
			playClip(winClip);
			gameController.Win();
		}
  }

  public void Retry() {
    transform.position = initialPosition;
		active = true;
		playClip(bgmClip);
  }

	private void playClip(AudioClip clip) {
		audioSource.Stop();
		audioSource.clip = clip;
		audioSource.Play();
	}
}
