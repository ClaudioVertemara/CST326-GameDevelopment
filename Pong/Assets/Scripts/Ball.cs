using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Claudio Vertemara
//CST 326 Pong (Project 1)
//Feb 2, 2020

public class Ball : MonoBehaviour
{
    public float startballSpeed = 5.0f;
    public float ballSpeed = 5f;

    Rigidbody rb;
    MeshRenderer mr;

    public GameObject gm;

    AudioSource ballAS;
    public AudioClip midBounce;
    public AudioClip sideBounce;

    // Start is called before the first frame update
    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        mr = gameObject.GetComponent<MeshRenderer>();

        ballAS = gameObject.GetComponent<AudioSource>();

        SpawnBall(true, -1);
        gm.GetComponent<GameManager>().SpawnModifiers();
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

        transform.localPosition = new Vector3(0, 0.5f, 0);
        transform.localRotation = Quaternion.identity;

        ballSpeed = 5;

        mr.material.color = Color.white;

        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag == "LPaddle") {
            ballSpeed += 1;
            mr.material.color = Color.red;
        }

        if (collision.gameObject.tag == "RPaddle") {
            ballSpeed += 1;
            mr.material.color = Color.blue;
        }

        if (collision.gameObject.name == "TopPL") {
            rb.AddForce(new Vector3(1, 0, 1) * ballSpeed);
            ballAS.PlayOneShot(sideBounce);
        } else if (collision.gameObject.name == "MidPL") {
            rb.AddForce(new Vector3(1, 0, 0) * ballSpeed);
            ballAS.PlayOneShot(midBounce);
        } else if (collision.gameObject.name == "BotPL") {
            rb.AddForce(new Vector3(1, 0, -1) * ballSpeed);
            ballAS.PlayOneShot(sideBounce);
        }

        if (collision.gameObject.name == "TopPR") {
            rb.AddForce(new Vector3(-1, 0, 1) * ballSpeed);
            ballAS.PlayOneShot(sideBounce);
        } else if (collision.gameObject.name == "MidPR") {
            rb.AddForce(new Vector3(-1, 0, 0) * ballSpeed);
            ballAS.PlayOneShot(midBounce);
        } else if (collision.gameObject.name == "BotPR") {
            rb.AddForce(new Vector3(-1, 0, -1) * ballSpeed);
            ballAS.PlayOneShot(sideBounce);
        }
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Modifier") {
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.name == "BigBall") {
            gameObject.transform.localScale = new Vector3(3, 1, 3);
        }

        if (other.gameObject.name == "RedirectBall") {
            if (mr.material.color != Color.white) {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            if (mr.material.color == Color.red) {
                rb.AddForce(new Vector3(1, 0, 0) * 100);
            } else if (mr.material.color == Color.blue) {
                rb.AddForce(new Vector3(-1, 0, 0) * 100);
            }
        }
    }
}
