using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxHealth = 5;
    public int currentHealth;
    public int CurrentHealth
    {
        get => currentHealth;
        set
        {
            if (value <= 0)
            {
                Kill();
            }
            else
            {
                currentHealth = value;
            }
        }
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    internal void Damage(int damage)
    {
        CurrentHealth -= damage;
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
}
