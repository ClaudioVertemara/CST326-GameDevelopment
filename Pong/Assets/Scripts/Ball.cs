using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float startballSpeed = 5.0f;
    public float ballSpeed = 5f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();

        SpawnBall(true, -1);
    }

    public void SpawnBall(bool firstSpawn, int player) {
        gameObject.transform.position = new Vector3(0, 0.5f, Random.Range(-7.0f, 7.0f));

        float randomRotation = 0;
        if (firstSpawn == true) {
            int randomPlayer = Random.Range(1, 3);

            if (randomPlayer == 1) {
                randomRotation = Random.Range(-20f, -160f);
            } else {
                randomRotation = Random.Range(20f, 160f);
            }
        } else {
            if (player == 1) {
                randomRotation = Random.Range(-20f, -160f);
            } else if (player == 2) {
                randomRotation = Random.Range(20f, 160f);
            }
        }

        gameObject.transform.Rotate(0, randomRotation, 0);
        rb.AddForce(transform.forward * startballSpeed);
    }

    public void resetBall () {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.localRotation = Quaternion.identity;

        ballSpeed = 5;
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag == "Paddle") {
            ballSpeed += 1;
        }
        
        if (collision.gameObject.name == "TopPL") {
            rb.AddForce(new Vector3(1, 0, 1) * ballSpeed);
        } else if (collision.gameObject.name == "MidPL") {
            rb.AddForce(new Vector3(1, 0, 0) * ballSpeed);
        } else if (collision.gameObject.name == "BotPL") {
            rb.AddForce(new Vector3(1, 0, -1) * ballSpeed);
        }

        if (collision.gameObject.name == "TopPR") {
            rb.AddForce(new Vector3(-1, 0, 1) * ballSpeed);
        } else if (collision.gameObject.name == "MidPR") {
            rb.AddForce(new Vector3(-1, 0, 0) * ballSpeed);
        } else if (collision.gameObject.name == "BotPR") {
            rb.AddForce(new Vector3(-1, 0, -1) * ballSpeed);
        }
    }
}
