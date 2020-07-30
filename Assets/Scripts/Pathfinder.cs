using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TMPro;
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
    private Queue<Waypoint> _queue = new Queue<Waypoint>();
    private bool _isPathfinding = false;

    private void Start()
    {
        InitialiseWaypoints();        
        FindPath();
    }

    private void InitialiseWaypoints()
    {
        IndicateStartWaypoint();
        IndicateEndWaypoint();
        LoadWaypoints();
    }

    private void IndicateStartWaypoint()
    {
        if (_startWaypoint != null)
        {
            _startWaypoint.SetTopColor(Color.green);
        }
    }

    private void IndicateEndWaypoint()
    {
        if (_endWaypoint != null)
        {
            _endWaypoint.SetTopColor(Color.red);
        }
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

    private void FindPath()
    {
        _isPathfinding = true;
        _queue.Enqueue(_startWaypoint);
        while(_isPathfinding && _queue.Count > 0)
        {
            var searchWaypoint = _queue.Dequeue();
            HaltOnWaypointFound(searchWaypoint);
            ExploreNeighbours(searchWaypoint);
            searchWaypoint.IsExplored = true;
        }
    }

    private void HaltOnWaypointFound(Waypoint searchWaypoint)
    {
        if (searchWaypoint == _endWaypoint)
        {
            IndicateEndWaypoint();
            _isPathfinding = false;
        }
    }

    private void ExploreNeighbours(Waypoint searchPosition)
    {
        if (!_isPathfinding) return;
        foreach (var direction in _directions)
        {
            var gridPosition = searchPosition.GetGridPosition();
            var explorePosition = gridPosition + direction;
            if (_grid.TryGetValue(explorePosition, out Waypoint exploreWaypoint))
            {
                QueueSearchWaypoint(exploreWaypoint);
            }
            else
            {
                Debug.Log($"No cube at explore position {explorePosition}");
            }
        }
    }

    private void QueueSearchWaypoint(Waypoint searchWaypoint)
    {
        if (!searchWaypoint.IsExplored)
        {
            searchWaypoint.SetTopColor(Color.blue);
            _queue.Enqueue(searchWaypoint);
        }
    }
}
