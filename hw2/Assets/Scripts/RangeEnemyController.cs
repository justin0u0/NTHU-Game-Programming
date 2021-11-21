using UnityEngine;

public class RangeEnemyController : MonoBehaviour
{
	public GameObject bulletPrefab;
	public float attackCooldown;
	public float bulletSpeed;

	private float nextAttack;
	private GameObject player;
	private Collider theCollider;

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.Find("Knight");

		nextAttack = Time.time + 3.0f;

		theCollider = gameObject.GetComponent<Collider>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Time.time > nextAttack && theCollider.enabled)
		{
			nextAttack = Time.time + attackCooldown;


			Rigidbody bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

			Vector3 direction = player.transform.position - transform.position;
			direction.y = 0;
			direction.Normalize();
			bullet.velocity = direction * bulletSpeed;

			Debug.Log($"Attack from {transform.name}, direction: {direction}");
		}
	}
}
