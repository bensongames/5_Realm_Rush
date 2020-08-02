using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private EnemyMovement _enemyPrefab;
    [SerializeField] private AudioClip _spawnSFX;
    [SerializeField] private bool _spawnEnemies = true;
    [Tooltip("Delay in seconds")] [Range(0.1f, 120f)] [SerializeField] private float _spawnDelay = 3f;
    [Range(0.1f, 120f)] [SerializeField] private float _enemyMovementSpeed = 2f;

    private int _enemySpawnedCount = 0;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (_spawnEnemies)
        {
            var enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity, transform);
            enemy.MovementSpeed = _enemyMovementSpeed;
            UpdateScore();
            PlaySpawnSound();            
            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private void PlaySpawnSound()
    {
        if (_spawnSFX != null)
        {
            _audioSource.PlayOneShot(_spawnSFX);
        }        
    }

    private void UpdateScore()
    {
        _enemySpawnedCount += 1;
        _scoreText.text = $"score {_enemySpawnedCount}";
    }
}
