using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    int coinAmount;

    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        coinAmount = 100;
        coinText.text = "Coins: " + coinAmount.ToString("000000");
    }

    public void IncreaseCoins(string enemyName) {
        if (enemyName.Contains("EnemyA")) {
            coinAmount += 20;
        } else if (enemyName.Contains("EnemyB")) {
            coinAmount += 10;
        }

        coinText.text = "Coins: " + coinAmount.ToString("000000");
    }

    public bool BuyWeapon() {
        if (coinAmount >= 50) {
            coinAmount -= 50;
            coinText.text = "Coins: " + coinAmount.ToString("000000");

            return true;
        }

        return false;
    }
}
