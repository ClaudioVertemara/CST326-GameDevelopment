using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    public Waypoint currentDestination;
    public WaypointManager waypointManager;
    private int currentIndexWaypoint = 0;
    public float speed = 1;

    int health;
    int orgHealth;
    CoinManager coinManager;

    public GameObject healthBar;

    public void Initialize(WaypointManager waypointManager, CoinManager coinManager) {
        this.waypointManager = waypointManager;
        this.coinManager = coinManager;

        GetNextWaypoint();
        transform.position = currentDestination.transform.position; // Move to WP0
        GetNextWaypoint();

        if (gameObject.name.Contains("EnemyA")) {
            health = 50;
        } else if (gameObject.name.Contains("EnemyB")) {
            health = 30;
        }
        orgHealth = health;
    }

    void Update() {
        Vector3 direction = currentDestination.transform.position - transform.position;
        if (direction.magnitude < .2f && currentIndexWaypoint <= 23) {
            GetNextWaypoint();
        }

        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    private void GetNextWaypoint() {
        currentDestination = waypointManager.GetNeWaypoint(currentIndexWaypoint);
        currentIndexWaypoint++;
    }

    public void ReduceHealth() {
        if (health > 0) {
            health--;
            healthBar.transform.localScale = new Vector3((float)health / orgHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
            
            if (health <= 0) {
                coinManager.IncreaseCoins(gameObject.name);
                transform.parent.gameObject.GetComponent<EnemyManager>().EnemyDied();
                transform.parent.gameObject.GetComponent<AudioSource>().Play();

                Destroy(gameObject);
            }
        }

        //Debug.Log(gameObject.name + " Health: " + health);
    }
}
