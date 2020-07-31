using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class EnemyMovement : MonoBehaviour
{
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
            yield return new WaitForSeconds(1f);
        }
    }
}
