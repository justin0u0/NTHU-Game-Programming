using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasController : MonoBehaviour {
    public Image[] hearts;

    public Text scoreText;

    public Text highScoreText;

    public PlayerController playerController;

    // Start is called before the first frame update
    void Start() {
        playerController = GameObject.Find("UnityChan").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < hearts.Length; i++) {
            if (i < playerController.health) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }

        scoreText.text = $"SCORE: {playerController.score}";
        highScoreText.text = $"HIGH SCORE: {playerController.highscore}";
    }
}
