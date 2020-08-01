using UnityEngine;
using UnityEngine.SocialPlatforms;

[ExecuteInEditMode]
[SelectionBase]
[DisallowMultipleComponent]
[RequireComponent(typeof(TextMesh))]
[RequireComponent(typeof(Waypoint))]
public class WaypointEditor : MonoBehaviour
{

    private TextMesh _textMesh;
    private Waypoint _waypoint;

    private void Awake()
    {
         _waypoint = gameObject.GetComponentInChildren<Waypoint>();
        _textMesh = gameObject.GetComponentInChildren<TextMesh>();
    }

    private void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        var gridSize = _waypoint.GetGridSize();
        var gridPosition = _waypoint.GetGridPosition();
        transform.position = new Vector3(gridPosition.x * gridSize, 0f, gridPosition.y * gridSize);
    }

    private void UpdateLabel()
    {
        var gridPosition = _waypoint.GetGridPosition();
        var labelText = $"{gridPosition.x},{gridPosition.y}";
        if (_textMesh != null) _textMesh.text = labelText;
        gameObject.name = $"({labelText})";
    }

}
