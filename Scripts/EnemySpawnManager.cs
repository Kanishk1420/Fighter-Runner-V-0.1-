using System.Collections;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public static EnemySpawnManager instance; // Singleton instance

    public GameObject enemyPrefab; // Reference to the enemy prefab to spawn
    public Transform[] spawnPoints; // Array of spawn points for enemies
    public float initialSpawnRate = 0.5f; // Initial spawn rate in seconds
    public float minSpawnRate = 0.5f; // Minimum spawn rate in seconds
    public float spawnRateIncreaseInterval = 35f; // Interval to increase spawn rate
    public float spawnRateIncreaseAmount = 0.1f; // Amount to increase spawn rate
    public float initialEnemySpeed = 5f; // Initial speed of enemies
    public float maxEnemySpeed = 10f; // Maximum speed of enemies

    private float _spawnTime; // Time to spawn the next enemy (private field)

    // Public property with a getter and setter for spawnTime
    public float spawnTime
    {
        get { return _spawnTime; }
        set { _spawnTime = value; }
    }

    private float currentSpawnRate; // Current spawn rate
    private float nextSpawnRateIncreaseTime; // Time to increase spawn rate next

    void Awake()
    {
        // Check if instance already exists
        if (instance == null)
        {
            // If not, set instance to this
            instance = this;
        }
        // If instance already exists and it's not this:
        else if (instance != this)
        {
            // Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Initialize spawn time and spawn rate
        spawnTime = Time.time + initialSpawnRate;
        currentSpawnRate = initialSpawnRate;
        nextSpawnRateIncreaseTime = Time.time + spawnRateIncreaseInterval;
    }

    void Update()
    {
        // Check if it's time to spawn an enemy
        if (Time.time > spawnTime)
        {
            SpawnEnemy();
            spawnTime = Time.time + currentSpawnRate;
        }

        // Check if it's time to increase spawn rate
        if (Time.time > nextSpawnRateIncreaseTime)
        {
            IncreaseSpawnRate();
            nextSpawnRateIncreaseTime = Time.time + spawnRateIncreaseInterval;
        }
    }

    void SpawnEnemy()
    {
        // Choose a random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate the enemy prefab at the chosen spawn point
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        // Set the speed of the enemy
        float enemySpeed = Mathf.Lerp(initialEnemySpeed, maxEnemySpeed, (Time.time - spawnTime) / spawnRateIncreaseInterval);
        enemy.GetComponent<Rigidbody2D>().velocity = Vector2.down * enemySpeed; // Move the enemy downwards
    }

    void IncreaseSpawnRate()
    {
        // Increase the spawn rate and clamp it between minSpawnRate and initialSpawnRate
        currentSpawnRate = Mathf.Clamp(currentSpawnRate - spawnRateIncreaseAmount, minSpawnRate, initialSpawnRate);
    }
}
