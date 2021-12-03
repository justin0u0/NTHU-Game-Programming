using UnityEngine;

public class PigController : MonoBehaviour
{
	public float maxImpulse;
	public AudioClip pigDieClip;

	private GameController gameController;
	private AudioSource audioSource;

	void Start()
	{
		gameController = GameObject.Find("GameController").GetComponent<GameController>();
		audioSource = GameObject.Find("ScoreCanvas").GetComponent<AudioSource>();
	}

	void Update()
	{

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		// Debug.Log($"impulse: {other.relativeVelocity.magnitude}");
		if (other.relativeVelocity.magnitude > maxImpulse)
		{
			GameObject.Destroy(gameObject);

			GameObject.Find("ScoreCanvas").GetComponent<ScoreController>().score += 1000;

			audioSource.PlayOneShot(pigDieClip, 1.0f);

			gameController.numberOfPigs--;
			if (gameController.numberOfPigs == 0)
			{
				gameController.NextStage();
			}
		}
	}
}
