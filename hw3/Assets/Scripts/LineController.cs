using UnityEngine;

public class LineController : MonoBehaviour
{
	public LineRenderer[] lineRenderers;
	public Transform[] lineStartPositions;
	public Transform center;
	public Transform idlePosition;
	public float maxLength;
	public GameObject birdPrefab;
	public float birdPositionOffset;
	public float force;
	public AudioClip birdShootClip;

	private bool isMouseDown;
	private Vector3 currentPosition;
	private Rigidbody2D bird;
	private Collider2D birdCollider;
	private AudioSource audioSource;

	void Start()
	{
		lineRenderers[0].positionCount = 2;
		lineRenderers[1].positionCount = 2;
		lineRenderers[0].SetPosition(0, lineStartPositions[0].position);
		lineRenderers[1].SetPosition(0, lineStartPositions[1].position);

		createBird();

		audioSource = gameObject.GetComponent<AudioSource>();
	}

	void Update()
	{
		if (isMouseDown)
		{
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = 10;

			currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
			currentPosition = center.position + Vector3.ClampMagnitude(currentPosition - center.position, maxLength);

			setLines(currentPosition);

			if (birdCollider != null)
			{
				birdCollider.enabled = true;
			}
		}
		else
		{
			resetLines();
		}
	}

	void OnMouseDown()
	{
		isMouseDown = true;
	}

	void OnMouseUp()
	{
		isMouseDown = false;
		if (bird != null)
		{
			shoot();
		}
	}

	private void resetLines()
	{
		currentPosition = idlePosition.position;
		setLines(currentPosition);
	}

	private void setLines(Vector3 position)
	{
		lineRenderers[0].SetPosition(1, position);
		lineRenderers[1].SetPosition(1, position);

		if (bird != null)
		{
			Vector3 dir = position - center.position;
			bird.transform.position = position + dir.normalized * birdPositionOffset;
			bird.transform.right = -dir.normalized;
		}
	}

	private void createBird()
	{
		bird = Instantiate(birdPrefab).GetComponent<Rigidbody2D>();
		bird.isKinematic = true;

		birdCollider = bird.GetComponent<Collider2D>();
		birdCollider.enabled = false;
	}

	private void shoot()
	{
		bird.isKinematic = false;

		Vector3 birdForce = (currentPosition - center.position) * force * -1;
		bird.velocity = birdForce;

		audioSource.PlayOneShot(birdShootClip, 1.0f);

		bird = null;
		birdCollider = null;

		Invoke("createBird", 2);

		GameObject.Find("ScoreCanvas").GetComponent<ScoreController>().shoots++;
	}
}
