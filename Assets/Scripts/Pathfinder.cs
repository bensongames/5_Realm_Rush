using System.Collections.Generic;
using System.Linq;
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
    private Waypoint _searchWaypoint;
    private List<Waypoint> _path = new List<Waypoint>();

    private void InitialiseWaypoints()
    {
        LoadWaypoints();
        IndicateStartWaypoint();
        IndicateEndWaypoint();
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

    private void BreadthFirstSearch()
    {
        _isPathfinding = true;
        _queue.Enqueue(_startWaypoint);
        while(_isPathfinding && _queue.Count > 0)
        {
            _searchWaypoint = _queue.Dequeue();
            HaltOnWaypointFound();
            ExploreNeighbours();
            _searchWaypoint.IsExplored = true;
        }
    }


    private void CreatePath()
    {
        _path.Add(_endWaypoint);
        var exploredFrom = _endWaypoint.ExploredFrom;
        while (exploredFrom != _startWaypoint)
        {
            _path.Add(exploredFrom);
            exploredFrom = exploredFrom.ExploredFrom;
        }
        _path.Add(_startWaypoint);
        _path.Reverse();
    }

    private void HaltOnWaypointFound()
    {
        if (_searchWaypoint == _endWaypoint)
        {
            IndicateStartWaypoint();
            IndicateEndWaypoint();
            _isPathfinding = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!_isPathfinding) return;
        foreach (var direction in _directions)
        {
            var gridPosition = _searchWaypoint.GetGridPosition();
            var explorePosition = gridPosition + direction;
            if (_grid.TryGetValue(explorePosition, out Waypoint exploreWaypoint))
            {
                QueueExploreWaypoint(exploreWaypoint);
            }
        }
    }

    private void QueueExploreWaypoint(Waypoint exploreWaypoint)
    {
        if (!exploreWaypoint.IsExplored && !_queue.Contains(exploreWaypoint))
        {            
            exploreWaypoint.ExploredFrom = _searchWaypoint;
            _queue.Enqueue(exploreWaypoint);
        }
    }

    public List<Waypoint> GetPath()
    {
        InitialiseWaypoints();
        BreadthFirstSearch();
        CreatePath();
        return _path;
    }
}
