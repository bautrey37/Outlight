using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public EnemyData EnemyData;
    public CampData CampData;

    private float timeBetweenSpawn = 5f;
    private int maxEnemies = 1;
    private List<Enemy> spawnedEnemies;
    private float nextSpawnTime;

    private void Awake()
    {
        spawnedEnemies = new List<Enemy>();
        nextSpawnTime = Time.time;
        timeBetweenSpawn = CampData.SpawnFrequency;
        maxEnemies = CampData.MaxSpawnedEnemies;
        GetComponent<Health>().InitMaxHealth(CampData.Health);
    }

    private void Start()
    {
        spawnedEnemies.Add(SpawnEnemy());
    }

    private void Update()
    {
        spawnedEnemies = spawnedEnemies.FindAll(e => e != null);
        if (IsEnemySpawnAvailable())
        {
            if (nextSpawnTime < Time.time)
            {
                spawnedEnemies.Add(SpawnEnemy());
            }
        }
    }

    bool IsEnemySpawnAvailable()
    {
        if (spawnedEnemies.Count >= maxEnemies)
        {
            return false;
        }
        return true;
    }

    Enemy SpawnEnemy()
    {
        nextSpawnTime = Time.time + timeBetweenSpawn;

        Enemy enemy = Instantiate(EnemyData.EnemyPrefab, transform.position + new Vector3(1-2*Random.value, 1-2*Random.value), Quaternion.identity, null);
        return enemy;
    }
}
