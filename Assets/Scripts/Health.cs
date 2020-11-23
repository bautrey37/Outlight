using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxHealth;
    Animator anim;
    public HealthBar healthBarPrefab;
    public HealthBar hbinst;

    public int currentHealth;
    public int CurrentHealth
    {
        get => currentHealth;
        set { hbinst.SetHealth(value);  if (value <= 0) { Kill(); } else { currentHealth = value; } }
    }


    private void Awake()
    {
        anim = GetComponent<Animator>();
        InitHB();
    }

    public void InitHB()
    {
        if (hbinst == null)
        {
        Vector3 hbpos = transform.position;
        hbpos.y += 1.3f;
        hbinst = Instantiate(healthBarPrefab, hbpos, Quaternion.identity, transform);
        }
    }

    public void InitMaxHealth(int val)
    {
        InitHB();
        MaxHealth = val;
        CurrentHealth = MaxHealth;
        hbinst.SetMaxHealth(MaxHealth);
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
