using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/StructureData")]
public class StructureData : ScriptableObject
{
    public string Name;
    public int Cost;
    public int Health;
    public string Shortcut;
    public Sprite Icon;
    public Structure StructurePrefab;
}
