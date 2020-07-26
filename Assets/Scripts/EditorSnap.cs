using UnityEngine;
using UnityEngine.SocialPlatforms;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{

    [SerializeField] [Range(1f, 20f)] private float _gridSize = 10f;
    [SerializeField] private bool _allowVertical = false;

    private void Update()
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

}
