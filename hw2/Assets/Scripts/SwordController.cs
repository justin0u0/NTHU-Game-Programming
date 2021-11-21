using UnityEngine;

public class SwordController : MonoBehaviour
{
	public float smooth;

	private Quaternion initialRotation;
	private Quaternion finalRotation;

	private bool canSwing;
	private PlayerController playerController;

	// Start is called before the first frame update
	void Start()
	{
		initialRotation = transform.localRotation;
		finalRotation = initialRotation;

		canSwing = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (canSwing && Input.GetMouseButtonDown(0))
		{
			finalRotation = Quaternion.Euler(90, 0, 60);
			canSwing = false;
		}

		float angle = Quaternion.Angle(transform.localRotation, finalRotation);
		if (angle < 1)
		{
			transform.localRotation = initialRotation;
			finalRotation = initialRotation;
			canSwing = true;
		}
		else
		{
			transform.localRotation = Quaternion.Slerp(transform.localRotation, finalRotation, smooth * Time.deltaTime);
		}
	}

	void OnTriggerStay(Collider other)
	{
		Debug.Log($"sword hit: {other.transform.name}");
		if (IsSwinging() && other.CompareTag("Enemy"))
		{
			other.GetComponent<EnemyController>().GetHit();		
		}
	}

	public bool IsSwinging()
	{
		return !canSwing;
	}
}
