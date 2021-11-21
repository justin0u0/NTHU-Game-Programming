using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 0.08f;
    public float jumpSpeed = 10.0f;
    private bool isGrounded = true;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
    }

    void FixedUpdate() {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + move * speed);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            rb.velocity += Vector3.up * jumpSpeed;
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.R) || rb.position.y < -3) {
            rb.transform.position = new Vector3(0, -0.2f, 0);
        }
        // rb.angularVelocity = Vector3.zero;
        if (move != Vector3.zero) {
            transform.rotation = Quaternion.LookRotation(move);
        }
    }

    void OnCollisionEnter(Collision o) {
        isGrounded = true;
    }
}
