using UnityEngine;

public class BulletController : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.name == "Knight")
		{
			other.gameObject.GetComponent<PlayerController>().GetHit(0.2f);
			Destroy(gameObject);
		}

		if (other.transform.parent != null && other.transform.parent.CompareTag("Wall"))
		{
			Destroy(gameObject);
		}
	}
}
