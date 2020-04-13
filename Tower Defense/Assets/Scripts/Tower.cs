using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameManager gameManager;
    public CoinManager coinManager;

    int towerHealth;
    int orgHealth;
    public GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {
        towerHealth = 100;
        orgHealth = towerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceHealth() {
        towerHealth -= 20;
        healthBar.transform.localScale = new Vector3((float)towerHealth / orgHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);

        if (towerHealth <= 0) {
            gameManager.EndGame();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            Destroy(other.gameObject);

            ReduceHealth();
            coinManager.IncreaseCoins(gameObject.name);
        }
    }
}
