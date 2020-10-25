using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public EnemyData EnemyData;
    public float TimeBetweenSpawn = 5f;
    
    private float nextSpawnTime = 0;
    private float checkDistanceRadius = 2f;

    private void Start()
    {
        SpawnEnemy();
    }

    private void Update()
    {
        
    }

    void CheckIfEnemyIsSpawned()
    {

    }

    void SpawnEnemy()
    {
        nextSpawnTime = Time.time + TimeBetweenSpawn;

        Enemy enemy = GameObject.Instantiate(EnemyData.EnemyPrefab, transform.position, Quaternion.identity, null);
    }
}
