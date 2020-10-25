using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    StructureData structure;

    Health HealthComponent;

    private void Awake()
    {
        HealthComponent = gameObject.GetComponent<Health>();
    }

    private void Update()
    {
    
    }
}
