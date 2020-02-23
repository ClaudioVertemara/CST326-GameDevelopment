using System;
using UnityEngine;
using UnityEngine.UI;

//Claudio Vertemara
//CST 326 Mario (Project 2)
//Feb 23, 2020

public class Timer : MonoBehaviour
{
    public int startTime = 100;

    TimeSpan startT;
    TimeSpan nowT;
    TimeSpan timeDifference;

    public Text timeText;

    public bool stopTimer = false;

    public GameObject player;

    public Text gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        startT = new TimeSpan(System.DateTime.Now.Ticks);
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopTimer) {
            nowT = new TimeSpan(System.DateTime.Now.Ticks);

            timeDifference = nowT.Subtract(startT);

            timeText.text = ("TIME\n" + (startTime - (int)timeDifference.TotalSeconds));

            if (startTime - (int)timeDifference.TotalSeconds <= 0) {
                GameOver();
            }
        }
    }

    public void GameOver() {
        stopTimer = true;

        Destroy(player);

        Debug.Log("Game Over!");
        gameOverText.text = "Game Over!";
    }
}
