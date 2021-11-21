using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
	public GameObject turtlePrefab;
	public GameObject slimePrefab;
	private GameObject player;

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.Find("Knight");
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.childCount == 0) {
			// upper-left: (-1.8, 0.5, 8.1)
			// bottom-right: (2.7, 0.5, 0)

			for (int i = 0; i < 3; i++) {
				bool isTurtle = Random.Range(0, 2) == 0;

				Vector3 spawnPosition = player.transform.position;
				while (Vector3.Distance(spawnPosition, player.transform.position) < 1) {
					float x = Random.Range(-1.8f, 2.7f);
					float z = Random.Range(0.0f, 8.1f);
					spawnPosition = new Vector3(x, 0.5f, z);
				}

				if (isTurtle) {
					Instantiate(turtlePrefab, spawnPosition, Quaternion.identity, transform);
				} else {
					Instantiate(slimePrefab, spawnPosition, Quaternion.identity, transform);
				}
			}
		}
	}
}
