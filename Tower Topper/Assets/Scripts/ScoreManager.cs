using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public float score;
    public float highscore;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;

        if (!PlayerPrefs.HasKey("highscore")) {
            PlayerPrefs.SetFloat("highscore", 0);
        }
        highscore = PlayerPrefs.GetFloat("highscore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(float height) {
        score = height;

        scoreText.text = score.ToString("0.00");
    }
}
