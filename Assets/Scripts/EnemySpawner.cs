using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private EnemyMovement _enemyPrefab;
    [SerializeField] private bool _spawnEnemies = true;
    [Tooltip("Delay in seconds")] [Range(0.1f, 120f)] [SerializeField] private float _spawnDelay = 3f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (_spawnEnemies)
        {
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity, transform);
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
