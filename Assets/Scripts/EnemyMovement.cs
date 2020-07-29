using UnityEngine;

[DisallowMultipleComponent]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private System.Collections.Generic.List<Cube> _path;

    private void Start()
    {
        PrintAllWaypoints();
    }

    private void PrintAllWaypoints()
    {
        foreach (var waypoint in _path)
        {
            Debug.Log(waypoint.name);
        }
    }
}
