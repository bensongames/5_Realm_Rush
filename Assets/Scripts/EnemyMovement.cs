using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private System.Collections.Generic.List<Waypoint> _path;

    private void Start()
    {
        StartCoroutine(FollowPath());
    }

    private IEnumerator FollowPath()
    {
        Debug.Log("Starting Patrol");
        foreach (var waypoint in _path)
        {
            if (waypoint != null)
            {
                Debug.Log($"Moving to position {waypoint.name}");
                transform.position = waypoint.transform.position;
            }
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("Ending Patrol");
    }
}
