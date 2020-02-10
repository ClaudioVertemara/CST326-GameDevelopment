using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Claudio Vertemara
//CST 326 Pong (Project 1)
//Feb 2, 2020

public class ScoreManager : MonoBehaviour
{
    public int p1Score = 0;
    public int p2Score = 0;

    public Text p1Text;
    public Text p2Text;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int p1Scored() {
        p1Score++;

        //Debug.Log("Left Paddle Scored! [" + p1Score + "-" + p2Score + "]");
        p1Text.text = p1Score.ToString();

        p1Text.color = Color.red;
        p2Text.color = Color.red;

        if (p1Score >= 11) {
            p1Wins();
            return 1;
        }

        return 0;
    }

    public int p2Scored() {
        p2Score++;

        //Debug.Log("Right Paddle Scored! [" + p1Score + "-" + p2Score + "]");
        p2Text.text = p2Score.ToString();

        p1Text.color = Color.blue;
        p2Text.color = Color.blue;

        if (p2Score >= 11) {
            p2Wins();
            return 1;
        }

        return 0;
    }

    void p1Wins() {
        //Debug.Log("Game Over, Left Paddle Wins!");
        winText.text = "Left Paddle Wins!\n[" + p1Score + " - " + p2Score + "]";

        p1Text.text = "";
        p2Text.text = "";

        p1Score = 0;
        p2Score = 0;
    }

    void p2Wins() {
        //Debug.Log("Game Over, Right Paddle Wins!");
        winText.text = "Right Paddle Wins!\n[" + p1Score + " - " + p2Score + "]";

        p1Text.text = "";
        p2Text.text = "";

        p1Score = 0;
        p2Score = 0;
    }

    public void restartGameText() {
        winText.text = "";

        p1Text.text = p1Score.ToString();
        p2Text.text = p2Score.ToString();

        p1Text.color = Color.white;
        p2Text.color = Color.white;
    }
}
