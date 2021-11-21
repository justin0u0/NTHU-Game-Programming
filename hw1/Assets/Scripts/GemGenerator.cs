using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemGenerator : MonoBehaviour {
    public GameObject gemPrefab;
    private GameObject gem;

    // gemt is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (gem == null) {
            int gemX = Random.Range(-4, 4) * 3; // available values: -12, -9, ..., +12
            int gemZ = Random.Range(-4, 4) * 3; // available values: -12, -9, ..., +12
            gem = Instantiate(gemPrefab, new Vector3(gemX, 1.2f, gemZ), Quaternion.identity);
        }
    }
}
