using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  private bool moveLeft = true;
	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
	}

  void FixedUpdate() {
    if (moveLeft) {
      Vector3 move = new Vector3(-3 * Time.deltaTime, 0, 0);
      transform.position += move;
      if (transform.position.x < 0.0f) {
        moveLeft = false;

        Vector3 characterScale = transform.localScale;
        characterScale.x *= -1;
        transform.localScale = characterScale;
      }
    } else {
      Vector3 move = new Vector3(3 * Time.deltaTime, 0, 0);
      transform.position += move;
      if (transform.position.x >= 10.0f) {
        moveLeft = true;

        Vector3 characterScale = transform.localScale;
        characterScale.x *= -1;
        transform.localScale = characterScale;
      }
    }
  }

  void OnTriggerEnter2D(Collider2D hit) {
    print(hit.transform.name);
    if (hit.transform.name == "Player") {
      hit.GetComponent<PlayerController>().Reset();
    }
  }
}
