using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Group
{
    public GameObject enemy;
    public float spawnTime;
    public int numberOfEnemies;

    public Group(GameObject enemy, float spawnTime, int numberOfEnemies) {
        this.enemy = enemy;
        this.spawnTime = spawnTime;
        this.numberOfEnemies = numberOfEnemies;
    }
}

[System.Serializable]
public struct Wave
{
    public Group[] enemyGroups;

    public Wave(Group[] enemyGroups) {
        this.enemyGroups = enemyGroups;
    }
}


public class EnemyManager : MonoBehaviour
{
    public GameObject EnemyA;
    public GameObject EnemyB;
    public float timeToWaitA = 1;
    public float timeToWaitB = 1.5f;
    public Wave currentWave;

    public WaypointManager waypointManager;
    public CoinManager coinManager;

    void Start()
    {

        Group groupA = new Group(EnemyA, timeToWaitA, 5);
        Group groupB = new Group(EnemyB, timeToWaitB, 3);

        currentWave = new Wave(new Group[2] { groupA, groupB });

        SpawnWave(currentWave);
    }

    private void SpawnWave(Wave newWave)
    {
        foreach (Group group in newWave.enemyGroups)
        {
            StartCoroutine(SpawnGroup(group));
        }
    }

    private IEnumerator SpawnGroup(Group @group)
    {
        while (@group.numberOfEnemies > 0)
        {
            yield return new WaitForSeconds(@group.spawnTime);
            GameObject enemy = Instantiate(@group.enemy, transform);
            enemy.GetComponent<Enemy>().Initialize(waypointManager, coinManager);
            @group.numberOfEnemies--;
        }
    }
}
