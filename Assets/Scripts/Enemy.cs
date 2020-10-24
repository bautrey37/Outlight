using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private List<Health> TargetsInRange;
    private float speed = 1f;
    private Transform target;

    private void Awake()
    {
        TargetsInRange = new List<Health>();
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
        if (TargetsInRange == null) return;

        Transform ClosestDistance = null;
        //TargetsInRange = FindObjectOfTypeAll<Health>
        foreach (Health target in TargetsInRange)
        {
            if (ClosestDistance == null)
            {
                ClosestDistance = target.transform;
            }
            if (Vector3.SqrMagnitude(transform.position - target.transform.position) < Vector3.SqrMagnitude(ClosestDistance.position))
            {
                ClosestDistance = target.transform;
                Debug.Log("Found new closest target");
            }
            
        }
        target = ClosestDistance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health target = collision.GetComponent<Health>();
        if (target != null)
        {
            TargetsInRange.Add(target);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Health target = collision.GetComponent<Health>();
        if (target != null)
        {
            TargetsInRange.Remove(target);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Health target = collision.GetComponent<Health>();
        if (target != null)
        {
            if (TargetsInRange.Contains(target))
            {
                TargetsInRange.Add(target);
            }
        }
    }
}
