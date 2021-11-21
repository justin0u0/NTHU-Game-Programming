using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public int maxHealth = 3;
    public int health = 3;
    public int score = 0;
    public int highscore = 0;
    public int lastScore = 0;

    // Start is called before the first frame update
    void Start() {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update() {
        if (health <= 0) {
            // teleport back to start point
            transform.position = new Vector3(-11.75f, 0, -12f);
            transform.eulerAngles = new Vector3(0, 90f, 0);
            lastScore = score;
            if (score > highscore) {
                highscore = score;
            }
            health = maxHealth;
            score = 0;
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Spike") {
            health--;
        }
    }

    public void resetHighScore() {
        highscore = 0;
    }
}
