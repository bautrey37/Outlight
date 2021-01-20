using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/ResourceData")]
public class ResourceData : ScriptableObject
{
    [Header("Attributes")]
    [Space]
    [Range(5,20)]
    public int Income;
}
