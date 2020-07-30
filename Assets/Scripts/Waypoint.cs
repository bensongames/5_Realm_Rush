using UnityEngine;

[DisallowMultipleComponent]
public class Waypoint : MonoBehaviour
{

    private Vector2Int _gridPosition;
    public const int _gridSize = 10;

    public int GetGridSize()
    {
        return _gridSize;
    }

    public Vector2 GetGridPosition()
    {
        var xPos = Mathf.RoundToInt(transform.position.x / _gridSize);
        var yPos = Mathf.RoundToInt(transform.position.z / _gridSize);
        return new Vector2Int(xPos, yPos);
    }

}
