using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    // waypoints array. Add waypoints to the list via unity editor
    [SerializeField] private GameObject[] waypoints;

    // keep track of waypoints index 
    private int currentWaypoint = 0;

    [SerializeField] private float speed = 2f;

    
    private void Update()
    {
        // calculate two distance between two vectors. waypoint and object
        if (Vector2.Distance(waypoints[currentWaypoint].transform.position, transform.position) < .1f)
        {
            currentWaypoint ++;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
        // move platform frame by frame. Time.deltaTime is used to assign the speed, with consideration to frame rates on different devices
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * speed);
    }
}
