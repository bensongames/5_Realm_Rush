using System;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Pathfinder : MonoBehaviour
{

    [SerializeField] private Waypoint _startWaypoint;
    [SerializeField] private Waypoint _endWaypoint;

    private Dictionary<Vector2Int, Waypoint> _grid = new Dictionary<Vector2Int, Waypoint>();

    private void Start()
    {
        InitialiseWaypoints();
    }

    private void InitialiseWaypoints()
    {
        if (_startWaypoint != null)
        {
            _startWaypoint.SetTopColor(Color.blue);
        }
        if (_endWaypoint != null)
        {
            _endWaypoint.SetTopColor(Color.red);
        }
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
