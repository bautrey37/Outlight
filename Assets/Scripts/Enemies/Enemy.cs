using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData EnemyData;

    private Transform target;
    private List<Transform> TargetsInRange;
    private float movementSpeed;
    private int attackStrength;
    private float attackSpeed;
    private float attackDistance = 0.5f;
    private float nextAttack = 0f;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        TargetsInRange = new List<Transform>();
        movementSpeed = EnemyData.Speed;
        attackStrength = EnemyData.AttackStrength;
        attackSpeed = EnemyData.AttackSpeed;
        GetComponent<Health>().MaxHealth = EnemyData.Health;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
    }

    void Update()
    {
        FindClosestTarget();
        if (target != null)
        {
            if (target.position.x < transform.position.x) spriteRenderer.flipX = true;

            if (Vector3.Distance(transform.position, target.position) < attackDistance)
            {
                if (nextAttack < Time.time)
                {
                    Attack();
                }
            } else
            {
                float step = movementSpeed * Time.deltaTime; // calculate distance to move
                transform.position = Vector2.MoveTowards(transform.position, target.position, step);
                EnemyData.Moving.Play();
            }
        }
    }

    void FindClosestTarget()
    {
        if (TargetsInRange.Count.Equals(0)) return;

        TargetsInRange = TargetsInRange.FindAll(e => e != null);

        Transform ClosestDistance = null;
        foreach (Transform target in TargetsInRange)
        {
            if (ClosestDistance == null)
            {
                ClosestDistance = target;
            }
            if (Vector3.SqrMagnitude(transform.position - target.position)
                < Vector3.SqrMagnitude(transform.position - ClosestDistance.position))
            {
                ClosestDistance = target;
                //Debug.Log("Found new closest target");
            }   
        }

        // switch to now follow target instead of waypoint
        WaypointFollower WF = GetComponent<WaypointFollower>();
        if (WF != null) WF.Waypoint = null;

        target = ClosestDistance;
    }

    void Attack()
    {
        //Debug.Log("Attack Target");
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null) targetHealth.Damage(attackStrength);
        nextAttack = Time.time + attackSpeed;
        FindClosestTarget();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Structure target = collision.GetComponent<Structure>();
        if (target != null)
        {
            TargetsInRange.Add(target.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Structure target = collision.GetComponent<Structure>();
        if (target != null)
        {
            TargetsInRange.Remove(target.transform);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Structure target = collision.GetComponent<Structure>();
        if (target != null)
        {
            if (TargetsInRange.Contains(target.transform))
            {
                TargetsInRange.Add(target.transform);
            }
        }
    }
}
