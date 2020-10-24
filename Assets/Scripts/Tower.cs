using System;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
    public Bullet BulletPrefab;
    public float TimeBetweenBullets = 0.1f;
    public int Damage = 1;

    private List<Health> EnemiesInRange;
    private float NextBulletTime;
    private StructureData currentStructureData;

    private void Awake()
    {
        EnemiesInRange = new List<Health>();
        
    }

    private void OnDestroy()
    {

    }

    private void Update()
    {

        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos = new Vector3(
            Mathf.Round(mousepos.x - 0.5f) + 0.5f, Mathf.Round(mousepos.y - 0.5f) + 0.5f, 0);

        transform.position = mousepos;
        if (Time.time > NextBulletTime && EnemiesInRange.Count > 0)
        {
            Fire();
        }
    }

    private void Fire()
    {
        NextBulletTime = Time.time + TimeBetweenBullets;
        Bullet b = Instantiate(BulletPrefab, transform.position, Quaternion.identity, null);
        EnemiesInRange = EnemiesInRange.FindAll(e => e != null);
        Health closest = EnemiesInRange[0];
        //float minVal = float.MaxValue;
        //
        //EnemiesInRange.ForEach((enemy) =>
        //{
        //    float val = (basepoint.transform.position - enemy.transform.position).sqrMagnitude;
        //    if (val < minVal)
        //        {
        //            closest = enemy;
        //            minVal = val;
        //        }
        //});
        b.Target = closest;
        b.Damage = Damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health enemy = collision.GetComponent<Health>();
        if (enemy != null)
        {
            EnemiesInRange.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Health enemy = collision.GetComponent<Health>();
        if (enemy != null)
        {
            EnemiesInRange.Remove(enemy);
        }
    }
}
