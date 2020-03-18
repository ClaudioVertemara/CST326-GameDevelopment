using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
  public Waypoint[] waypoints;

  void Awake()
  {

    waypoints = GetComponentsInChildren<Waypoint>();
    
  }

  public Waypoint GetNeWaypoint(int currentIndex)
  {
    return waypoints[currentIndex++];
  }
}
