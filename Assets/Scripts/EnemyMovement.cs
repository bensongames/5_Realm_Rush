using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class EnemyMovement : MonoBehaviour
{

    public float MovementSpeed = 2f;
    
    private ParticleFactory _particleFactory;


    private void Start()
    {
        var pathFinder = FindObjectOfType<Pathfinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
        _particleFactory = FindObjectOfType<ParticleFactory>();
    }

    private IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (var waypoint in path)
        {
            if (waypoint != null)
            {
                transform.position = waypoint.transform.position;
            }
            yield return new WaitForSeconds(MovementSpeed);
        }
        AttackPlayerBase();
    }

    private void AttackPlayerBase()
    {
        Destroy(gameObject);
        _particleFactory.CreateAttackPlayerBaseParticles(transform.position);
    }
}
