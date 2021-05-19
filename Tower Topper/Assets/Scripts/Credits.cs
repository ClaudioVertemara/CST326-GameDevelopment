using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    AudioSource buttonAudio;

    // Start is called before the first frame update
    void Start()
    {
        buttonAudio = GameObject.Find("ButtonAudio").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenuButton() {
        SceneManager.LoadScene("Menu");
        buttonAudio.Play();
    }
}
