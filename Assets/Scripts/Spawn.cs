using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Enemy EnemyPrefab;
    public float TimeBetweenSpawn = 5f;

    private float nextSpawnTime = 0;

    private void Update()
    {
        
    }

    void CheckIfEnemyIsSpawned()
    {

    }

    void SpawnEnemy()
    {
        nextSpawnTime = Time.time + TimeBetweenSpawn;

        GameObject.Instantiate(EnemyPrefab, transform.position, Quaternion.identity, null);
    }
}
