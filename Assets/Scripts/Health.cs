using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    internal int MaxHealth = 5;
    Animator anim;
    public HealthBar healthBarPrefab;
    private HealthBar hbinst;

    public int CurrentHealth
    {
        get => currentHealth;
        set { hbinst.SetHealth(value);  if (value <= 0) { Kill(); } else { currentHealth = value; } }
    }

    private int currentHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        Vector3 hbpos = transform.position;
        hbpos.y += 1.3f;
        hbinst = Instantiate(healthBarPrefab, hbpos, Quaternion.identity, transform);
        hbinst.SetMaxHealth(MaxHealth);
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
