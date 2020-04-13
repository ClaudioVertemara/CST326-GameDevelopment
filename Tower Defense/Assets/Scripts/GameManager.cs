using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public EnemyManager enemyManager;

    public GameObject startButton;
    public GameObject restartButton;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        enemyManager.StartEnemies();
        startButton.SetActive(false);
    }

    public void EndGame () {
        enemyManager.ResetEnemies();
        restartButton.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene("Game");
    }
}
