using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Waypoint currentDestination;
    public WaypointManager waypointManager;
    private int currentIndexWaypoint = 0;
    public float speed = 1;

    int health;
    CoinManager coinManager;

    public void Initialize(WaypointManager waypointManager, CoinManager coinManager) {
        this.waypointManager = waypointManager;
        this.coinManager = coinManager;

        GetNextWaypoint();
        transform.position = currentDestination.transform.position; // Move to WP0
        GetNextWaypoint();

        if (gameObject.name.Contains("EnemyA")) {
            health = 20;
        } else if (gameObject.name.Contains("EnemyB")) {
            health = 10;
        }
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
        health -= 3;

        if (health <= 0) {
            coinManager.GetComponent<CoinManager>().IncreaseCoins(gameObject.name);
            Destroy(gameObject);
        }

        Debug.Log(gameObject.name + " Health: " + health);
    }
}
