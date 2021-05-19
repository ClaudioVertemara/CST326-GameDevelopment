using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public float spawnTime = 5f;        // The amount of time between each spawn.
	public float spawnDelay = 3f;       // The amount of time before spawning starts.        
    //public int enemyIndex;
    public GameObject[] enemies;        // Array of enemy prefabs.
    
    public void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}
	
	void Spawn ()
	{
		// Instantiate a random enemy.
		int enemyIndex = Random.Range(0, enemies.Length);
		Instantiate(enemies[enemyIndex], transform.position, transform.rotation);
	}
}
//By Ethan Herndon