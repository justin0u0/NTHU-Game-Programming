using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float speed = 3.0f;
  public float jumpForce = 20.0f;
	public int score = 0;
	public Text text;

	private bool jump;
	private bool facingRight;
  private bool onGround;
	private Vector3 initp;
	private Vector3 inits;
	private Animator animator;

	// Start is called before the first frame update
	void Start()
	{
		jump = false;
		facingRight = true;
    onGround = true;

		initp = transform.position;
		inits = transform.localScale;

		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && onGround) jump = true;

		if (Input.GetKeyDown(KeyCode.R)) Reset();

		text.text = $"Score: {score}";
	}

	void FixedUpdate()
	{
		float move = Input.GetAxis("Horizontal");

		print($"move: {move}");
		animator.SetFloat("speed", Mathf.Abs(move));

		GetComponent<Rigidbody2D>().velocity = new Vector2(move * speed, GetComponent<Rigidbody2D>().velocity.y);

		if (move > 0 && !facingRight || move < 0 && facingRight) Flip();

    if (onGround && jump) 
		{
			animator.SetBool("onGround", false);
      jump = false;
      onGround = false;
      // print($"jump: {jumpForce}");
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpForce));
		}
	}

  void OnCollisionEnter2D(Collision2D hit) {
    if (hit.transform.name == "Ground" || hit.transform.name == "Wall" || hit.transform.name == "Wall2") {
      onGround = true;
			animator.SetBool("onGround", true);
    }
  }

	private void Flip()
	{
		facingRight = !facingRight;

		Vector3 characterScale = transform.localScale;
		characterScale.x *= -1;
		transform.localScale = characterScale;
	}

	public void Reset() {
		transform.position = initp;
		transform.localScale = inits;
		score = 0;
	}
}
