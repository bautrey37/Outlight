﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    private StructureData structure;
    private float TimeBetweenMaintenance = 1f;
    private float NextMaintenanceTime = 0;

    Health HealthComponent;

    private void Awake()
    {
        HealthComponent = gameObject.GetComponent<Health>();
        if (HealthComponent != null)
        {
            HealthComponent.MaxHealth = structure.Health;
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (Time.time >= NextMaintenanceTime && structure != null)
        {
            NextMaintenanceTime = Time.time + TimeBetweenMaintenance;
            Events.RemoveMoney(structure.MaintenanceCost);
        }
        
    }

    public void setStructureData(StructureData data)
    {
        structure = data;
    }
}
