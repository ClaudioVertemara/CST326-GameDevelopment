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
            smScript.p1Scored();

            bScript.resetBall();
            bScript.SpawnBall(false, 2);
        } else if (ball.transform.localPosition.x <= -15) {
            smScript.p2Scored();

            bScript.resetBall();
            bScript.SpawnBall(false, 1);
        }
    }
}
