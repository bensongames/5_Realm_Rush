using UnityEngine;

[DisallowMultipleComponent]
public class Waypoint : MonoBehaviour
{

    [SerializeField] private Color _exploredColor;

    public bool IsPathway = false;
    public bool IsExplored;
    public Waypoint ExploredFrom;

    private const int _gridSize = 10;

    private void Update()
    {
        if (IsExplored)
        {
            SetTopColor(_exploredColor);
        }
    }

    private void OnMouseOver()
    {
        print(gameObject.name);
    }

    public int GetGridSize()
    {
        return _gridSize;
    }

    public Vector2Int GetGridPosition()
    {
        var xPos = Mathf.RoundToInt(transform.position.x / _gridSize);
        var yPos = Mathf.RoundToInt(transform.position.z / _gridSize);
        return new Vector2Int(xPos, yPos);
    }

    public void SetTopColor(Color color)
    {
        var top = transform.Find("Top");
        if (top != null)
        {
            var topMeshRenderer = top.GetComponent<MeshRenderer>();
            if (topMeshRenderer != null)
            {
                topMeshRenderer.material.color = color;
            }
        }
    }

}
