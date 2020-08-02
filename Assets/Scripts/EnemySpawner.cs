using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyMovement _enemyPrefab;
    [SerializeField] private AudioClip _spawnSFX;
    [SerializeField] private bool _spawnEnemies = true;
    [Tooltip("Delay in seconds")] [Range(0.1f, 120f)] [SerializeField] private float _spawnDelay = 3f;
    [Range(0.1f, 120f)] [SerializeField] private float _enemyMovementSpeed = 2f;

    private AudioSource _audioSource;

    private void OnEnable()
    {
        GameEventManager.OnGameStart += StartSpawning;
        GameEventManager.OnGameOver += StopSpawning;
    }

    private void OnDisable()
    {
        GameEventManager.OnGameStart -= StartSpawning;
        GameEventManager.OnGameOver -= StopSpawning;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();        
    }

    private void StartSpawning()
    {
        _spawnEnemies = true;
        StartCoroutine(SpawnEnemies());
    }

    private void StopSpawning()
    {
        _spawnEnemies = false;
    }

    private IEnumerator SpawnEnemies()
    {
        while (_spawnEnemies)
        {
            SpawnEnemy();
            PlaySpawnSound();
            GameEventManager.IncreaseScore(1);
            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private void SpawnEnemy()
    {
        var enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity, transform);
        enemy.MovementSpeed = _enemyMovementSpeed;
    }

    private void PlaySpawnSound()
    {
        if (_spawnSFX != null)
        {
            _audioSource.PlayOneShot(_spawnSFX);
        }        
    }

}
