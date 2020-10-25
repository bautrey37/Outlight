using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public EnemyData EnemyData;
    public float TimeBetweenSpawn = 5f;
    public int MaxEnemies = 1;

    private List<Enemy> spawnedEnemies;
    private float nextSpawnTime;

    private void Awake()
    {
        spawnedEnemies = new List<Enemy>();
        nextSpawnTime = Time.time;
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
        if (spawnedEnemies.Count > MaxEnemies)
        {
            return false;
        }
        return true;
    }

    Enemy SpawnEnemy()
    {
        nextSpawnTime = Time.time + TimeBetweenSpawn;

        Enemy enemy = GameObject.Instantiate(EnemyData.EnemyPrefab, transform.position, Quaternion.identity, null);
        return enemy;
    }
}
