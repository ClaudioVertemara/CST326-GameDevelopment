using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Claudio Vertemara
//CST 326 Pong (Project 1)
//Feb 2, 2020

public class InputManager : MonoBehaviour
{
    public Transform leftPaddleT;
    public Transform rightPaddleT;

    public float paddleSpeed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftPaddleT.Translate(0, 0, (Input.GetAxis("LeftPaddle") * paddleSpeed * Time.deltaTime));
        rightPaddleT.Translate(0, 0, (Input.GetAxis("RightPaddle") * paddleSpeed * Time.deltaTime));
    }
}
