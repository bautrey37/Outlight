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
        Health enemy = null;
        while (EnemiesInRange.Count > 0)
        {
            if (EnemiesInRange[0] == null)
            {
                EnemiesInRange.RemoveAt(0);
            }
            else
            {
                enemy = EnemiesInRange[0];
                break;
            }
        }
        if (enemy == null) return;

        Bullet projectile = GameObject.Instantiate(
        BulletPrefab, this.transform.position, Quaternion.identity, null);
        projectile.Target = enemy;
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

