using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public AudioClip deathSound;

	private AudioSource audioSource;
	private GameObject player;

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.Find("Knight");

		audioSource = gameObject.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 lookPosition = player.transform.position;
		lookPosition.y = transform.position.y;
		transform.LookAt(lookPosition);
	}

	public void GetHit()
	{
		Debug.Log($"{transform.name} get hit");

		gameObject.GetComponentInChildren<ParticleSystem>().Play();
		gameObject.GetComponent<Collider>().enabled = false;

		player.GetComponent<PlayerController>().AddScore();

		audioSource.PlayOneShot(deathSound, 1.0f);

		Object.Destroy(gameObject, 1.0f);
	}
}
