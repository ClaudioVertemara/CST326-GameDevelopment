using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Claudio Vertemara
//CST 326 Space Invaders (Project 3)
//March 1, 2020

public class GameManager : MonoBehaviour
{
    public GameObject sm;
    public GameObject em;

    public GameObject player;

    public Transform barricades;
    public GameObject barricade;

    public GameObject[] barArr;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBarricades();
    }

    void SpawnBarricades() {
        barArr = new GameObject[4];

        for (int i = 0; i < 4; i++) {
            barArr[i] = Instantiate(barricade, new Vector3((i * 2) - 3, -3, 0), Quaternion.identity, barricades);
        }
    }

    void DestroyBarricades() {
        for (int i = 0; i < 4; i++) {
            if (barArr[i] != null) {
                Destroy(barArr[i]);
            }
        }
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
    }
}
