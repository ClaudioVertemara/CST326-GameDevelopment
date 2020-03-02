using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Claudio Vertemara
//CST 326 Space Invaders (Project 3)
//March 1, 2020

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    public GameObject[] enArr;

    float moveCountdown;
    int moveDirection;
    bool justMovedDown;

    float shootCountdown;
    public GameObject enemyBullet;
    public Transform bullets;

    float enemy4Countdown;

    public int enemyCount;

    public GameObject gm;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    public void SpawnEnemies() {
        //Creates an Array of Enemy GameObjects
        enArr = new GameObject[50];
        int goNum = 0;

        // Instantiates all the enemies
        for (int j = 0; j < 5; j++) {
            for (int i = 0; i < 10; i++) {
                if (j == 0) {
                    enArr[goNum] = Instantiate(enemy1, new Vector2((i - 4.5f) * 0.75f, (-j + 3.5f) * 0.75f), Quaternion.identity, transform);
                } else if (j < 3) {
                    enArr[goNum] = Instantiate(enemy2, new Vector2((i - 4.5f) * 0.75f, (-j + 3.5f) * 0.75f), Quaternion.identity, transform);
                } else if (j < 5) {
                    enArr[goNum] = Instantiate(enemy3, new Vector2((i - 4.5f) * 0.75f, (-j + 3.5f) * 0.75f), Quaternion.identity, transform);
                }

                goNum++;
            }
        }

        moveCountdown = 0.8f;
        moveDirection = 1;
        justMovedDown = false;

        shootCountdown = 2f;

        enemy4Countdown = 5f;

        enemyCount = 50;
    }

    public void DestroyEnemies() {
        for (int i = 0; i < 50; i++) {
            if (enArr[i] != null) {
                Destroy(enArr[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveCountdown -= Time.deltaTime;
        shootCountdown -= Time.deltaTime;
        enemy4Countdown -= Time.deltaTime;

        if (moveCountdown < 0) {

            if ((transform.position.x >= 2 || transform.position.x <= -2) && justMovedDown == false) {
                moveDirection *= -1;
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
                justMovedDown = true;
            } else {
                if (moveDirection == 1) { //Right
                    transform.position = new Vector3(transform.position.x + 0.4f, transform.position.y, transform.position.z);
                } else if (moveDirection == -1) { //Left
                    transform.position = new Vector3(transform.position.x - 0.4f, transform.position.y, transform.position.z);
                }

                justMovedDown = false;
            }

            moveCountdown = 0.8f * (enemyCount / 50f);
        }

        if (shootCountdown < 0) {
            GameObject bull = Instantiate(enemyBullet, enArr[SelectRandomEnemy()].transform.position, Quaternion.identity, bullets);
            bull.GetComponent<Bullet>().ShootBullet(-1);

            shootCountdown = 2f;
        }

        if (enemy4Countdown < 0) {
            GameObject en4 = Instantiate(enemy4, new Vector3(-5, 3, 0), Quaternion.identity);
            Destroy(en4, 10);

            enemy4Countdown = 8f;
        }
    }

    int SelectRandomEnemy() {
        int ranEn = Random.Range(0, 50);

        if (enArr[ranEn] == null) {
            return SelectRandomEnemy();
        } else {
            return ranEn;
        }
    }

    public void UpdateEnemyCount() {
        enemyCount--;

        if (enemyCount <= 0) {
            gm.GetComponent<GameManager>().ResetGame();
        }
    }
}
