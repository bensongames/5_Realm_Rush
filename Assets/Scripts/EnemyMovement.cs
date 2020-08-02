using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] ParticleSystem _playerBaseReachedPrefab;
    [SerializeField] private float _movementSpeed = 2f;

    private void Start()
    {
        var pathFinder = FindObjectOfType<Pathfinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    private IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (var waypoint in path)
        {
            if (waypoint != null)
            {
                transform.position = waypoint.transform.position;
            }
            yield return new WaitForSeconds(_movementSpeed);
        }
        ReachedPlayerBase();
    }

    private void ReachedPlayerBase()
    {
        var playerBaseReachedParticles = Instantiate(_playerBaseReachedPrefab, transform.position, Quaternion.identity);
        var destroyDelay = playerBaseReachedParticles.main.duration;
        Destroy(gameObject);
        Destroy(playerBaseReachedParticles.gameObject, destroyDelay);
    }
}
