using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public ScoreManager sm;

    public Button pauseButton;
    public GameObject continueButton;
    public GameObject mainMenuButton;

    public GameObject gameOverPanel;
    public Text gameOverBody;

    AudioSource buttonAudio;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        buttonAudio = GameObject.Find("ButtonAudio").GetComponent<AudioSource>();

        continueButton.SetActive(false);
        mainMenuButton.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver() {
        pauseButton.interactable = false;
        Time.timeScale = 0;

        gameOverPanel.SetActive(true);
        if (sm.score > sm.highscore) {
            gameOverBody.text = "New Highscore!\n\n" + sm.score.ToString("0.00");
            PlayerPrefs.SetFloat("highscore", sm.score);
        } else {
            gameOverBody.text = "Score: " + sm.score.ToString("0.00") + "\n\nHighscore: " + sm.highscore.ToString("0.00");
        }
    }

    public void CreditsButton() {
        SceneManager.LoadScene("Credits");
        buttonAudio.Play();
    }

    public void PauseButton() {
        pauseButton.interactable = false;
        continueButton.SetActive(true);
        mainMenuButton.SetActive(true);

        Time.timeScale = 0;
        buttonAudio.Play();
    }

    public void ContinueButton() {
        pauseButton.interactable = true;
        continueButton.SetActive(false);
        mainMenuButton.SetActive(false);

        Time.timeScale = 1;
        buttonAudio.Play();
    }

    public void MainMenuButton() {
        SceneManager.LoadScene("Menu");
        buttonAudio.Play();
    }
}
