using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/CampData")]
public class CampData : ScriptableObject
{
    public string Name;
    public int Health;
    public int MaxSpawnedEnemies;
    public float SpawnFrequency;
    public Camp CampPrefab;
}
