using UnityEngine;

public class ItemController : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{

	}

  void OnTriggerEnter2D(Collider2D hit) {
    if (hit.transform.name == "Player") {
			hit.gameObject.GetComponent<PlayerController>().score++;
			float x = Random.Range(0.0f, 10.0f);
			transform.position = new Vector3(x, 0.02f, 0);
    }
  }
}
