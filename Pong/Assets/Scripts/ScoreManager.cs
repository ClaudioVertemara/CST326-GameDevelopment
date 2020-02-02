using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int p1Score = 0;
    public int p2Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (p1Score >= 11) {
            Debug.Log("Game Over, Left Paddle Wins!");
            p1Score = 0;
            p2Score = 0;
        } else if (p2Score >= 11) {
            Debug.Log("Game Over, Right Paddle Wins!");
            p1Score = 0;
            p2Score = 0;
        }
    }

    public void p1Scored() {
        p1Score++;
        Debug.Log("Left Paddle Scored! [" + p1Score + "-" + p2Score + "]");
    }

    public void p2Scored() {
        p2Score++;
        Debug.Log("Right Paddle Scored! [" + p1Score + "-" + p2Score + "]");
    }
}
