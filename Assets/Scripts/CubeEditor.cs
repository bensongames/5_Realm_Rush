using UnityEngine;
using UnityEngine.SocialPlatforms;

[ExecuteInEditMode]
[SelectionBase]
[DisallowMultipleComponent]
[RequireComponent(typeof(TextMesh))]
public class CubeEditor : MonoBehaviour
{

    [SerializeField] [Range(1f, 20f)] private float _gridSize = 10f;
    [SerializeField] private bool _allowVertical = false;

    private TextMesh _textMesh;

    private void Update()
    {
        ProcessPosition();
        DisplayPosition();
    }

    private void ProcessPosition()
    {
        Vector3 snapPosition;
        snapPosition.x = Mathf.RoundToInt(transform.position.x / _gridSize) * _gridSize;
        if (_allowVertical)
        {
            snapPosition.y = Mathf.RoundToInt(transform.position.y / _gridSize) * _gridSize;
        }
        else
        {
            snapPosition.y = 0f;
        }
        snapPosition.z = Mathf.RoundToInt(transform.position.z / _gridSize) * _gridSize;
        transform.position = snapPosition;
    }

    private void DisplayPosition()
    {
        if (_textMesh == null)
        {
            _textMesh = gameObject.GetComponentInChildren<TextMesh>();
        }
        var labelText = $"{transform.position.x / _gridSize},{transform.position.z / _gridSize}";
        _textMesh.text = labelText;
        gameObject.name = $"Cube ({labelText})";
    }

}
