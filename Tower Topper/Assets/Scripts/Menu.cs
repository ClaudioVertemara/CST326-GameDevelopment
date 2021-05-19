using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject howToPlayPanel;

    AudioSource buttonAudio;

    // Start is called before the first frame update
    void Start()
    {
        buttonAudio = GameObject.Find("ButtonAudio").GetComponent<AudioSource>();
        howToPlayPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton() {
        SceneManager.LoadScene("Game");
        buttonAudio.Play();
    }

    public void HowToPlayButton() {
        titleScreen.SetActive(false);
        howToPlayPanel.SetActive(true);
        buttonAudio.Play();
    }

    public void CreditsButton() {
        SceneManager.LoadScene("Credits");
        buttonAudio.Play();
    }

    public void ExitGameButton() {
        Application.Quit();
    }

    public void BackButton() {
        titleScreen.SetActive(true);
        howToPlayPanel.SetActive(false);
        buttonAudio.Play();
    }
}
