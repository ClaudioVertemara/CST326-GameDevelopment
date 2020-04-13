using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<GameObject> EnemiesInRange;

    public GameObject target;
    public GameObject bullet;
    GameObject bullets;

    float shootTimer;

    // Start is called before the first frame update
    void Start()
    {
        EnemiesInRange = new List<GameObject>();
        bullets = GameObject.Find("Bullets");

        shootTimer = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) {
            transform.LookAt(target.transform);

            if (shootTimer < 0) {
                Instantiate(bullet, transform.GetChild(0).transform.position, Quaternion.identity, bullets.transform);

                shootTimer = 0.5f;
            } else {
                shootTimer -= Time.deltaTime;
            }
        } else {
            SetTarget();
        }
    }

    public void SetTarget() {
        UpdateFirstEnemy();

        if (!EnemiesInRange.Contains(target) && EnemiesInRange.Count > 0) {
            target = EnemiesInRange[0];
        } else if (EnemiesInRange.Count <= 0) {
            target = null;
        }
    }

    void UpdateFirstEnemy() {
        if (EnemiesInRange.Count > 0) {
            if (EnemiesInRange[0] == null) {
                EnemiesInRange.RemoveAt(0);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        EnemiesInRange.Add(other.gameObject);
        SetTarget();
    }

    private void OnTriggerExit(Collider other) {
        EnemiesInRange.Remove(other.gameObject);
        SetTarget();
    }
}
