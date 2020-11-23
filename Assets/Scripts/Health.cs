using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    internal int MaxHealth = 5;
    Animator anim;
    public int CurrentHealth
    {
        get => currentHealth;
        set { if (value <= 0) { Kill(); } else { currentHealth = value; } }
    }

    private int currentHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
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
        Events.HealthDestroyed(gameObject);
        if (anim != null)
        {
            anim.SetTrigger("Death");
        }
        Destroy(gameObject);
    }
}
