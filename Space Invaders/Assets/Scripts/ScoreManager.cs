using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Claudio Vertemara
//CST 326 Space Invaders (Project 3)
//March 1, 2020

public class ScoreManager : MonoBehaviour
{
    int score;
    public static int hiScore;

    public Text scoreText;
    public Text hiScoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;

        if (GameManager.firstGame == true) {
            hiScore = 0;
            GameManager.firstGame = false;
        } else {
            hiScoreText.text = "HI-SCORE\n" + hiScore.ToString("0000");
        }
    }

    public void UpdateScore(int enemyValue) {
        score += enemyValue;
        if (score > hiScore) {
            hiScore = score;
        }

        scoreText.text = "SCORE\n" + score.ToString("0000");
        hiScoreText.text = "HI-SCORE\n" + hiScore.ToString("0000");
    }

    public void ResetScore() {
        score = 0;

        scoreText.text = "SCORE\n" + score.ToString("0000");
    }
}
