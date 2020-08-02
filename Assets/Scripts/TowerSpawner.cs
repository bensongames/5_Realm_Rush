using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerSpawner : MonoBehaviour
{

    [SerializeField] private Transform _towerPrefab;
    [SerializeField] [Range(1, 10)] private int _towerLimit = 5;

    private int _towerCount = 0;

    public bool PlaceTower(Vector3 placePosition)
    {
        if (_towerCount < _towerLimit)
        {
            CreateNewTower(placePosition);
            return true;
        }
        else
        {
            MoveExistingTower(placePosition);
            return false;
        }

    }

    private void CreateNewTower(Vector3 placePosition)
    {
        _towerCount += 1;
        Instantiate(_towerPrefab, placePosition, Quaternion.identity, transform);
    }

    private static void MoveExistingTower(Vector3 placePosition)
    {
        print("Tower placement limit reached");
    }
}
