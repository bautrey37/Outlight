using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    Animator anim;
    public HealthBar healthBarPrefab;
    public HealthBar hbinst;

    private int maxHealth;
    private int currentHealth;
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
        maxHealth = val;
        CurrentHealth = maxHealth;
        hbinst.SetMaxHealth(maxHealth);
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
            //anim.SetTrigger("Death");
        }
        Destroy(gameObject);
    }
}
