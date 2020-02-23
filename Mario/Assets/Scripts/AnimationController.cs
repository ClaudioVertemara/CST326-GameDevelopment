using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Claudio Vertemara
//CST 326 Mario (Project 2)
//Feb 23, 2020

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public Transform characterTransform;
    public Rigidbody rb;
    public float speed = 3;
    float turbo = 1;
    public float jump = 5;
    bool onGround = false;

    // Update is called once per frame
    void FixedUpdate() {
        if (rb != null) {
            float forwardMovement = Input.GetAxis("Horizontal");
            onGround = Vector3.Dot(rb.velocity, Vector3.up) < .01;
            if (onGround && Input.GetKeyDown(KeyCode.Space)) {
                rb.velocity = Vector3.up * jump;
            }

            if (Input.GetKey(KeyCode.LeftShift)) {
                turbo = 2;
            } else {
                turbo = 1;
            }

            if (forwardMovement != 0) {
                float y = (forwardMovement < 0) ? -90 : 90;
                Vector3 input = new Vector3(0, y, 0);
                characterTransform.eulerAngles = input;
                rb.velocity = new Vector3((speed * turbo) * forwardMovement, rb.velocity.y, rb.velocity.z);
            } else {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
            }

            animator.SetFloat("Movement", Mathf.Abs(forwardMovement));
        }
    }
}
