using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerSpawner : MonoBehaviour
{

    [SerializeField] private Tower _towerPrefab;
    [SerializeField] [Range(1, 10)] private int _towerLimit = 5;

    private readonly Queue<Tower> _towerQueue = new Queue<Tower>();

    public void PlaceTower(Waypoint waypoint)
    {
        if (_towerQueue.Count < _towerLimit)
        {
            CreateNewTower(waypoint);
        }
        else
        {
            MoveOldestTower(waypoint);
        }

    }

    private void CreateNewTower(Waypoint waypoint)
    {        
        Tower newTower = Instantiate(_towerPrefab, waypoint.transform.position, Quaternion.identity, transform);
        waypoint.ContainsTower = true;
        newTower.BaseWaypoint = waypoint;
        _towerQueue.Enqueue(newTower);
    }

    private void MoveOldestTower(Waypoint waypoint)
    {
        var oldestTower = _towerQueue.Dequeue();
        oldestTower.BaseWaypoint.ContainsTower = false;
        waypoint.ContainsTower = true;
        oldestTower.BaseWaypoint = waypoint;
        oldestTower.transform.position = waypoint.transform.position;
        _towerQueue.Enqueue(oldestTower);
    }

}
