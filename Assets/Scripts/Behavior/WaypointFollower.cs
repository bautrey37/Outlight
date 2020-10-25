using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    public Waypoint Waypoint;
    public float Speed = 1f;

    void Start()
    {
    }

    void Update()
    {
        if (Waypoint == null) return;

        transform.position = Vector3.MoveTowards(transform.position, Waypoint.transform.position, Time.deltaTime * Speed);

        float distance = Vector3.SqrMagnitude(transform.position - Waypoint.transform.position);
        // really close to 0 equivalency
        if (distance < float.Epsilon)
        {
            Waypoint = Waypoint.GetNextWaypoint();
            if (Waypoint == null)
            {
                DestinationReached();
            }
        }
    }

    void DestinationReached()
    {
        //GameObject.Destroy(this.gameObject);
    }
}
