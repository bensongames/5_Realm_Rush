using System;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    private Dictionary<Vector2Int, Waypoint> _grid = new Dictionary<Vector2Int, Waypoint>();


    private void Start()
    {
        LoadWaypoints();
    }

    private void LoadWaypoints()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (var waypoint in waypoints)
        {
            var gridPosition = waypoint.GetGridPosition();
            var isOverLapping = _grid.ContainsKey(gridPosition);
            if (isOverLapping)
            {
                Debug.LogWarning($"Overlapping cube at {gridPosition}");
            }
            else
            {
                _grid.Add(gridPosition, waypoint);
            }
            
        }
    }
}
