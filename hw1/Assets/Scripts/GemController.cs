using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour {
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start() {
        playerController = GameObject.Find("UnityChan").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update() {
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
        playerController.score++;
    }
}
