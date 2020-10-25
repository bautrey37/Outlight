using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public List<Waypoint> NextWaypoints;

    public Waypoint GetNextWaypoint()
    {
        if (NextWaypoints.Count == 0) return null;
        return NextWaypoints[Random.Range(0, NextWaypoints.Count)];
    }

    void OnDrawGizmos()
    {
        if (NextWaypoints == null) return;
        Gizmos.color = Color.red;
        foreach (Waypoint waypoint in NextWaypoints)
        {
            Gizmos.DrawLine(transform.position, waypoint.transform.position);
        }

    }
}
