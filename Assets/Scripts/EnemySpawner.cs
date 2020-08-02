using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private EnemyMovement _enemyPrefab;
    [SerializeField] private bool _spawnEnemies = true;
    [Tooltip("Delay in seconds")] [Range(0.1f, 120f)] [SerializeField] private float _spawnDelay = 3f;
    [Range(0.1f, 120f)] [SerializeField] private float _enemyMovementSpeed = 2f;

    private int _enemySpawnedCount = 0;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (_spawnEnemies)
        {
            var enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity, transform);
            enemy.MovementSpeed = _enemyMovementSpeed;
            _enemySpawnedCount += 1;
            DisplayScore();
            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private void DisplayScore()
    {
        _scoreText.text = $"score {_enemySpawnedCount}";
    }
}
