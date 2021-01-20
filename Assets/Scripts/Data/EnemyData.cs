using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/EnemyData")]
public class EnemyData : ScriptableObject
{
    public Enemy EnemyPrefab;
    

    [Header("Attributes")]
    [Space]
    public string Name;
    [Range(0,20)]
    public int Health;
    [Range(0,10)]
    public int AttackStrength;
    [Range(0,1)]
    public float AttackSpeed;
    [Range(0,3)]
    public float MovementSpeed;

    [Header("Audio")]
    [Space]
    public AudioClipGroup Moving;
    public AudioClipGroup Attack;
}
