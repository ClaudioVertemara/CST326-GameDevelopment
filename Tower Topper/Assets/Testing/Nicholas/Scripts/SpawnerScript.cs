using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {
	
	public float spawnTime = 5f;        // The amount of time between each spawn.
	public float spawnDelay = 3f;       // The amount of time before spawning starts.        
    //public int enemyIndex;
    public GameObject[] enemies;        // Array of enemy prefabs.
    public GameObject clouds;
    public float maxHeight, moveSpeed = 4.0f;
    private bool cloudlayer;
    public void Start ()
	{
        // Start calling the Spawn function repeatedly after a delay .
        //InvokeRepeating("Spawn", spawnDelay, spawnTime);
        SpawnUpdated();
        cloudlayer = true;
	}
    
	public void Update()
    {
        if (transform.position.y < maxHeight)
        {
            Vector3 pos = transform.position;
            float step = moveSpeed * Time.deltaTime;
            pos.y += maxHeight*step;
            transform.position = Vector3.Lerp(transform.position, pos, moveSpeed);
        }
    }
    
    void Spawn ()
	{
		// Instantiate a random enemy.
		int enemyIndex = Random.Range(0, enemies.Length);
        Vector3 pos = transform.position;
        pos.z = 0;
        pos.y = pos.y + 4.0f;
        pos.x = /*0;*/Random.Range(-3.0f,3.0f);
		Instantiate(enemies[enemyIndex], pos, transform.rotation);
	}
    public void SpawnUpdated()
    {
        int enemyIndex = Random.Range(0, enemies.Length);
        Vector3 pos = transform.position;
        pos.z = 0;
        pos.y = pos.y + 4.0f;
        pos.x = Random.Range(-3.0f, 3.0f);
        Instantiate(enemies[enemyIndex], pos, transform.rotation);
    }
    public void setMax(float val)
    {
        if (maxHeight < val)
        {
            maxHeight = val;
        }
    }
}
//By Ethan Herndon