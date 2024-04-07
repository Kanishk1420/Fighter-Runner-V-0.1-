using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public float maxY;
    public float maxX;
    public float minY;
    public float minX;
    private EnemySpawnManager spawnManager; // Reference to the EnemySpawnManager script

    void Start()
    {
        // Find the EnemySpawnManager instance and assign it
        spawnManager = GameObject.Find("EnemySpawnManager").GetComponent<EnemySpawnManager>();
        if (spawnManager == null)
        {
            Debug.LogError("EnemySpawnManager instance is null!");
        }
        else
        {
            Debug.Log("EnemySpawnManager instance found!");
        }
    }




    void Update()
    {
        if (Time.time > spawnManager.spawnTime)
        {
            Spawn();
            spawnManager.spawnTime = Time.time + spawnManager.initialSpawnRate;
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
