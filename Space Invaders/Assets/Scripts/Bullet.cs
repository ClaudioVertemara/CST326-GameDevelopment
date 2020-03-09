using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Claudio Vertemara
//CST 326 Space Invaders (Project 3)
//March 1, 2020

public class Bullet : MonoBehaviour
{
    public float speed;

    Rigidbody2D rb2d;

    GameObject gm;

    public void Start() {
        gm = GameObject.Find("GameManager");
    }

    public void ShootBullet(int direction) {
        rb2d = GetComponent<Rigidbody2D>();

        if (direction == 1) {
            rb2d.velocity = Vector2.up * speed;
        } else {
            rb2d.velocity = Vector2.down * speed;
        }

        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.name == "Player") {
            gm.GetComponent<GameManager>().EndGame();
        } else if (collision.gameObject.name.Contains("Enemy")) {
            if (collision.gameObject != null) {
                collision.gameObject.GetComponent<Enemy>().DestroyEnemy();
            }
        } else {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
