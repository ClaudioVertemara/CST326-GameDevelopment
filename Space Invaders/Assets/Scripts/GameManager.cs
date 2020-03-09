using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Claudio Vertemara
//CST 326 Space Invaders (Project 3)
//March 1, 2020

public class GameManager : MonoBehaviour
{
    GameObject sm;
    GameObject em;

    GameObject player;

    GameObject barricades;
    public GameObject barricade;

    public GameObject[] barArr;

    public static GameManager gmInstance;

    float creditsTimer;

    public static bool firstGame;

    public Animator playerAnimator;
    bool endGame = false;
    float endTimer = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (firstGame != false) {
            firstGame = true;
        }

        if (SceneManager.GetActiveScene().name == "Game") {
            em = GameObject.Find("Enemies");
            sm = GameObject.Find("ScoreManager");
            player = GameObject.Find("Player");

            barricades = GameObject.Find("Barricades");

            SpawnBarricades();
        } else if (SceneManager.GetActiveScene().name == "Credits") {
            creditsTimer = 5;
        }
    }

    private void Update() {
        if (SceneManager.GetActiveScene().name == "Credits") {
            creditsTimer -= Time.deltaTime;

            if (creditsTimer < 0) {
                SceneManager.LoadScene(0);
            }
        }

        if (endGame == true) {
            if (endTimer < 0) {
                GameObject.Find("Player").SetActive(false);
                ResetGame();
            } else {
                endTimer -= Time.deltaTime;
            }
        }
    }

    void SpawnBarricades() {
        barArr = new GameObject[4];

        for (int i = 0; i < 4; i++) {
            barArr[i] = Instantiate(barricade, new Vector3((i * 2) - 3, -3, 0), Quaternion.identity, barricades.transform);
        }
    }

    void DestroyBarricades() {
        for (int i = 0; i < 4; i++) {
            if (barArr[i] != null) {
                Destroy(barArr[i]);
            }
        }
    }

    public void GoToGame() {
        SceneManager.LoadScene(1);
    }

    public void EndGame() {
        playerAnimator.SetTrigger("End");

        endGame = true;
    }

    public void ResetGame() {
        em.GetComponent<EnemyManager>().DestroyEnemies();
        em.transform.position = Vector3.zero;
        em.GetComponent<EnemyManager>().SpawnEnemies();

        sm.GetComponent<ScoreManager>().ResetScore();

        DestroyBarricades();
        SpawnBarricades();

        player.SetActive(true);
        player.transform.position = new Vector3(0, -4, 0);

        SceneManager.LoadScene(2);
    }
}
