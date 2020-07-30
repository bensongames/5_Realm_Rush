using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

[DisallowMultipleComponent]
public class Pathfinder : MonoBehaviour
{

    [SerializeField] private Waypoint _startWaypoint;
    [SerializeField] private Waypoint _endWaypoint;

    private Dictionary<Vector2Int, Waypoint> _grid = new Dictionary<Vector2Int, Waypoint>();
    private Vector2Int[] _directions = { 
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    private void Start()
    {
        InitialiseWaypoints();
        ExploreNeighbours();
    }

    private void InitialiseWaypoints()
    {
        if (_startWaypoint != null)
        {
            _startWaypoint.SetTopColor(Color.green);
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

    private void ExploreNeighbours()
    {
        foreach(var waypoint in _grid) { 
            foreach (var direction in _directions)
            {
                var gridPosition = waypoint.Value.GetGridPosition();
                var explorePosition = gridPosition + direction;
                if (_grid.TryGetValue(explorePosition, out Waypoint exploreWaypoint))
                {
                    exploreWaypoint.SetTopColor(Color.blue);
                }
                else
                {
                    Debug.Log($"No cube at explore position {explorePosition}");
                }
            }
        }
    }
}
