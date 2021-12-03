using UnityEngine;

public class YellowBirdController : MonoBehaviour
{
	public float scale;

	private Rigidbody2D bird;
	private bool once;

	void Start()
	{
		once = true;
		bird = gameObject.GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (once && Input.GetMouseButtonDown(0))
		{
			if (!bird.isKinematic) {
				Vector2 v = bird.velocity;
				// Debug.Log($"[before] bird velocity: {v}");

				bird.velocity = v * scale;
				// Debug.Log($"[after] bird velocity: {bird.velocity}");
				once = false;
			}
		}
	}
}
