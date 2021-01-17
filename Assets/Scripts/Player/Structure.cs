using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]

public class Structure : MonoBehaviour
{
    public StructureData structure;
    private float TimeBetweenMaintenance = 1f;
    private float NextMaintenanceTime = 0;

    Health HealthComponent;

    private void Awake()
    {
        HealthComponent = gameObject.GetComponent<Health>();
        if (HealthComponent != null)
        {
            HealthComponent.InitMaxHealth(structure.Health);
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
            if (Events.RequestMoney() < structure.MaintenanceCost && structure.MaintenanceCost > 0)
            {
                Destroy(gameObject);
            }
            Events.RemoveMoney(structure.MaintenanceCost);
        }
        
    }

    private void OnDestroy()
    {
        Destroy(HealthComponent);
    }

    public void setStructureData(StructureData data)
    {
        structure = data;
    }
}
