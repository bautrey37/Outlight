using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/SkillsData")]
public class SkillsData : ScriptableObject
{
    public string Name;
    public int Cost;
    public string Shortcut;
    public Sprite Icon;
    public Skill SkillPrefab;
}
