using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string Name;
    public int Health;
    public int AttackStrength;
    public float Speed;
    public Sprite Icon;
    public Enemy EnemyPrefab;
}
