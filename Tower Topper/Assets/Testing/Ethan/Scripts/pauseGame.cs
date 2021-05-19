using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class pauseGame : MonoBehaviour {

    private bool Pause = false;
    //private bool showGUI = false;
    public RawImage pauseImage;
    GameObject pauseAbortMission;
    
     void Start()
    {

    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 1;
            //SceneManager.LoadScene("Pause 3d"); //Code from Shoot'em game
        }

       
        if (Input.GetKeyDown("escape"))
        {
            Pause = !Pause;
            //unPause Player
            //Debug.Log("Unpause Game!");
            if (Pause == true)
            {
                Time.timeScale = 0;
                //Pause Player
                Pause = true;
                pauseImage.enabled = true;
                Debug.Log("Pause Game!");
            }
        }

        if (Pause == false)
        {
            Time.timeScale = 1;
            gameObject.transform.position = new Vector3(0.0f, 23.2f, 11.5f);
            Pause = false;
            pauseImage.enabled = false;     
         }
       

    }

}
//Created by Ethan Herndon
//Modified by: YOUR NAME HERE :D
