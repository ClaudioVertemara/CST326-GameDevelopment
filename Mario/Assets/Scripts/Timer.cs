using System;
using UnityEngine;
using UnityEngine.UI;

//Claudio Vertemara
//CST 326 Mario (Project 2)
//Feb 16, 2020

public class Timer : MonoBehaviour
{
    public int startTime = 400;

    TimeSpan startT;
    TimeSpan nowT;
    TimeSpan timeDifference;

    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        startT = new TimeSpan(System.DateTime.Now.Ticks);
    }

    // Update is called once per frame
    void Update()
    {
        nowT = new TimeSpan(System.DateTime.Now.Ticks);

        timeDifference = nowT.Subtract(startT);

        timeText.text = ("TIME\n" + (startTime - (int)timeDifference.TotalSeconds));
    }
}
