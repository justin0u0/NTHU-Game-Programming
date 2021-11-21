using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject prefabCube;
    private GameObject cube;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (cube == null) {
            float x = Random.Range(-5.0f, 5.0f);
            float z = Random.Range(-5.0f, 5.0f);
            cube = Instantiate(prefabCube, new Vector3(x, 0.5f, z), Quaternion.identity);
        }
    }
}
