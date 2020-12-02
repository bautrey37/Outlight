using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/SkillsData")]
public class SkillsData : ScriptableObject
{
    public Skill SkillPrefab;

    [Header("Attributes")]
    [Space]
    public string Name;
    [Range(0,10)]
    public int Cost;

    [Header("GUI Panel Attributes")]
    [Space]
    public string Shortcut;
    public Sprite Icon;
    
}
