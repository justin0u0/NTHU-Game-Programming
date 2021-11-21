using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 30.0f;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }
    
    void FixedUpdate() {
        if(Input.GetKey(KeyCode.UpArrow)) {
            transform.position += new Vector3(0 ,speed * Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.RightArrow)) {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.LeftArrow)) {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.DownArrow)) {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.W)) {
            GetComponent<Camera>().fieldOfView += 5;
        }
        if(Input.GetKey(KeyCode.S)) {
            GetComponent<Camera>().fieldOfView -= 5;
        }
    }
}
