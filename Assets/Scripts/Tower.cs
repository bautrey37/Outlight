using System;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{

    public float ShootDelay = 1f;
    public Bullet BulletPrefab;
    private float NextShootTime;
    public List<Health> EnemiesInRange;

    private void Awake()
    {
        EnemiesInRange = new List<Health>();
        NextShootTime = Time.time + ShootDelay;
    }

    private void Update()
    {
        if (NextShootTime <= Time.time)
        {
            Shoot();
            NextShootTime += ShootDelay;
        }
    }

    private void Shoot()
    {
        Health closest = null;
        float minVal = float.MaxValue;
        EnemiesInRange = EnemiesInRange.FindAll(e => e != null);
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
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Health enemy = collision.GetComponent<Health>();
        if (enemy != null)
        {
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

