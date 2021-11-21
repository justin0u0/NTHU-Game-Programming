using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour {
    // Start is called before the first frame update
    private GameObject panel;

    void Start() {
        panel = GameObject.Find("SettingsPanel");
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            if (panel.activeSelf) {
                panel.SetActive(false);
            } else {
                panel.SetActive(true);
            }
        }
    }
}
