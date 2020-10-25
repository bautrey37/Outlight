using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    StructureData structure;

    Health HealthComponent;

    private void Awake()
    {
        HealthComponent = GetComponent<Health>();
    }
    // Start is called before the first frame update
    void Start()
    {
        HealthComponent.CurrentHealth = structure.Health;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
