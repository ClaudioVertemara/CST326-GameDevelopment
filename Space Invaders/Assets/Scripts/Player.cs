using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Claudio Vertemara
//CST 326 Space Invaders (Project 3)
//March 1, 2020

public class Player : MonoBehaviour
{
    public float speed;

    public GameObject bullet;
    public Transform parent;

    public Animator playerAnimator;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            playerAnimator.SetTrigger("Shoot");

            GameObject bull = Instantiate(bullet, gameObject.transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity, parent);
            bull.GetComponent<Bullet>().ShootBullet(1);
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed, 0, 0);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5.9f, 5.9f), -4, 0);
    }
}
