using UnityEngine;

public class MeleeEnemyController : MonoBehaviour
{
	public float speed;

	private GameObject player;

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.Find("Knight");
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if (other.transform.name == "Knight") {
			EnemyController enemyController = gameObject.GetComponent<EnemyController>();
			enemyController.GetHit();

			player.GetComponent<PlayerController>().GetHit(0.4f);
		}
	}
}
