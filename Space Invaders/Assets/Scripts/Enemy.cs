using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Claudio Vertemara
//CST 326 Space Invaders (Project 3)
//March 1, 2020

public class Enemy : MonoBehaviour
{
    int enemyValue = 0;

    GameObject em;
    GameObject gm;
    GameObject sm;

    bool endEnemy = false;
    float endTimer = 1;

    // Start is called before the first frame update
    void Start()
    {
        em = GameObject.Find("Enemies");
        gm = GameObject.Find("GameManager");
        sm = GameObject.Find("ScoreManager");

        if (gameObject.name == "Enemy1(Clone)") {
            enemyValue = 30;
        } else if (gameObject.name == "Enemy2(Clone)") {
            enemyValue = 20;
        } else if (gameObject.name == "Enemy3(Clone)") {
            enemyValue = 10;
        } else if (gameObject.name == "Enemy4(Clone)") {
            enemyValue = 40;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Enemy4(Clone)") {
            transform.Translate(2 * Time.deltaTime, 0, 0);
        }

        if (endEnemy == true) {
            if (endTimer < 0) {
                Destroy(gameObject);
            } else {
                endTimer -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Bullet") {
            em.GetComponent<EnemyManager>().UpdateEnemyCount();
            sm.GetComponent<ScoreManager>().UpdateScore(enemyValue);
        } else if (collision.gameObject.name == "Player") {
            gm.GetComponent<GameManager>().EndGame();
        } else if (collision.gameObject.tag != "Enemy") {
            Destroy(collision.gameObject);
        }
    }

    public void DestroyEnemy() {
        GetComponent<Animator>().SetTrigger("Explode");

        endEnemy = true;
    }
}
