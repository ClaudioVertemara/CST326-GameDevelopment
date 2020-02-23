using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Claudio Vertemara
//CST 326 Mario (Project 2)
//Feb 23, 2020

public class Player : MonoBehaviour
{
    public GameObject Timer;

    int points = 0;
    public Text pointsText;

    int coins = 0;
    public Text coinsText;

    public Text gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Lava") {
            Destroy(gameObject);
            Timer.GetComponent<Timer>().GameOver();

            gameOverText.text = "Game Over!";
        }

        if (collision.gameObject.tag == "Goal") {
            Debug.Log("You Win!");
            Destroy(gameObject);
            Timer.GetComponent<Timer>().stopTimer = true;

            gameOverText.text = "Level Completed!";
        }

        if (collision.gameObject.tag == "DestroyableBlock") {
            Destroy(collision.gameObject);

            pointsIncrease();
        }

        if (collision.gameObject.tag == "Coin") {
            Destroy(collision.gameObject);

            coins += 1;
            if (coins < 10) {
                coinsText.text = ("x 0" + coins.ToString());
            } else {
                coinsText.text = ("x " + coins.ToString());
            }

            pointsIncrease();
        }
    }

    void pointsIncrease() {
        points += 100;

        if (points < 1000) {
            pointsText.text = ("MARIO\n" + "000" + points.ToString());
        } else if (points < 10000) {
            pointsText.text = ("MARIO\n" + "00" + points.ToString());
        } else {
            pointsText.text = ("MARIO\n" + "0" + points.ToString());
        }
    }
}
