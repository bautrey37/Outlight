using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/StructureData")]
public class StructureData : ScriptableObject
{
    public Structure StructurePrefab;

    [Header("Attributes")]
    [Space]
    public string Name;
    [Range(0,50)]
    public int Cost;
    [Range(0,5)]
    public int MaintenanceCost;
    [Range(0,100)]
    public int Health;

    [Header("GUI Panel Attributes")]
    [Space]
    public string Shortcut;
    public Sprite Icon;

    [Header("Audio")]
    [Space]
    public AudioClipGroup BuildSound;

    [Header("Bullet")]
    [Space]
    [Range(1,5)]
    public int BulletDamage;
    [Range(1,20)]
    public float BulletSpeed;
}
