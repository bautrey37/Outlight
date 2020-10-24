using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private List<Transform> TargetsInRange;
    private float speed = 1f;

    private void Awake()
    {
        TargetsInRange = new List<Transform>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        FindClosestTarget();
        if (target != null)
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);

            if (Vector3.Distance(transform.position, target.position) < 0.001f)
            {
                Debug.Log("Reached Target");
            }
        }
    }

    void FindClosestTarget()
    {
        if (TargetsInRange.Count.Equals(0)) return;

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
                Debug.Log("Found new closest target");
            }   
        }
        // remove walking on waypoint to now follow target
        GetComponent<WaypointFollower>().Waypoint = null;

        target = ClosestDistance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health target = collision.GetComponent<Health>();
        if (target != null)
        {
            TargetsInRange.Add(target.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Health target = collision.GetComponent<Health>();
        if (target != null)
        {
            TargetsInRange.Remove(target.transform);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Health target = collision.GetComponent<Health>();
        if (target != null)
        {
            if (TargetsInRange.Contains(target.transform))
            {
                TargetsInRange.Add(target.transform);
            }
        }
    }
}
