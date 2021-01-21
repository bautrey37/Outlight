using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/CampData")]
public class CampData : ScriptableObject
{
    public Camp CampPrefab;

    [Header("Attributes")]
    [Space]
    public string Name;
    [Range(1,100)]
    public int Health;
    [Range(1, 3)]
    public int MaxSpawnedEnemies;
    [Tooltip("In seconds")]
    [Range(0,5)]
    public float SpawnFrequency;
}
