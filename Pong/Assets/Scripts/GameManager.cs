using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Claudio Vertemara
//CST 326 Pong (Project 1)
//Feb 2, 2020

public class GameManager : MonoBehaviour
{
    public GameObject scoreManager;
    public GameObject ball;

    ScoreManager smScript;
    Ball bScript;

    public GameObject bigBall;
    public GameObject redirectBall;

    bool waitForRestart = false;

    // Start is called before the first frame update
    void Start()
    {
        smScript = scoreManager.GetComponent<ScoreManager>();
        bScript = ball.GetComponent<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.transform.localPosition.x >= 15) {
            if (smScript.p1Scored() == 1) {
                StartCoroutine(holdBeforeRestart());
            }

            bScript.resetBall();

            if (waitForRestart == false) {
                bScript.SpawnBall(false, 2);
                SpawnModifiers();
            }
        } else if (ball.transform.localPosition.x <= -15) {
            if (smScript.p2Scored() == 1) {
                StartCoroutine(holdBeforeRestart());
            }

            bScript.resetBall();

            if (waitForRestart == false) {
                bScript.SpawnBall(false, 1);
                SpawnModifiers();
            }
        }
    }

    public void SpawnModifiers() {
        bigBall.SetActive(true);
        redirectBall.SetActive(true);

        float bigBallX = Random.Range(-5f, 5f);
        float bigBallZ = Random.Range(-5f, 5f);

        float redirectBallX = Random.Range(-5f, 5f);
        float redirectBallZ = Random.Range(-5f, 5f);

        bigBall.transform.localPosition = new Vector3(bigBallX, 0.5f, bigBallZ);
        redirectBall.transform.localPosition = new Vector3(redirectBallX, 0.5f, redirectBallZ);

        // Respawn modifiers if they are too close to each other
        if (bigBallX == redirectBallX || Mathf.Abs(bigBallX - redirectBallX) <= 1f) {
            SpawnModifiers();
        } else if (bigBallZ == redirectBallZ || Mathf.Abs(bigBallZ - redirectBallZ) <= 1f) {
            SpawnModifiers();
        }
    }

    IEnumerator holdBeforeRestart() {
        waitForRestart = true;

        yield return new WaitForSeconds(5);

        smScript.restartGameText();

        bScript.SpawnBall(true, -1);
        SpawnModifiers();

        waitForRestart = false;
    }
}
