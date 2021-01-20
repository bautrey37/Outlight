using System;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
using System.Collections.Generic;

[RequireComponent(typeof(Structure))]

public class Tower : MonoBehaviour
{

    public float ShootDelay = 1f;
    public Bullet BulletPrefab;
    private float NextShootTime;
    public List<Health> EnemiesInRange;
    public AudioClipGroup ArrowShot;

    private int bulletDamage;
    private float bulletSpeed;


    private void Awake()
    {
        EnemiesInRange = new List<Health>();
        NextShootTime = Time.time + ShootDelay;
        StructureData data = GetComponent<Structure>().structure;
        bulletDamage = data.BulletDamage;
        bulletSpeed = data.BulletSpeed;
    }

    private void Update()
    {
        if (NextShootTime <= Time.time)
        {
            EnemiesInRange = EnemiesInRange.FindAll(e => e != null);
            if (EnemiesInRange.Count > 0)
            {
                Shoot();
                NextShootTime = Time.time + ShootDelay;
            }
        }
    }

    private void Shoot()
    {
        Health closest = null;
        float minVal = float.MaxValue;
        EnemiesInRange.ForEach((enemy) =>
        {
            float val = (transform.position - enemy.transform.position).sqrMagnitude;
            if (val < minVal)
            {
                closest = enemy;
                minVal = val;
            }
        });
        Bullet b = Instantiate(BulletPrefab, transform.position, Quaternion.identity, null);
        b.Target = closest;
        b.Damage = bulletDamage;
        b.Speed = bulletSpeed;
        ArrowShot.Play();

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger1");
        Health enemy = collision.GetComponent<Health>();
        if (enemy != null)
        {
            //Debug.Log("Enemy!");
            EnemiesInRange.Add(enemy);
        }
    }
    

    public void OnTriggerExit2D(Collider2D collision)
    {
        Health enemy = collision.GetComponent<Health>();
        if (enemy != null)
        {
            EnemiesInRange.Remove(enemy);
        }
    }
}

