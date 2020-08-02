using UnityEngine;

[DisallowMultipleComponent]
public class Waypoint : MonoBehaviour
{

    [SerializeField] private Color _exploredColor;
    

    public bool IsPathway = false;
    public bool IsExplored = false;
    public Waypoint ExploredFrom;

    private const int _gridSize = 10;
    private bool _containsTower = false;
    private TowerSpawner _towerSpawner;


    private void Start()
    {
        _towerSpawner = FindObjectOfType<TowerSpawner>();
    }

    private void Update()
    {
        if (IsExplored)
        {
            SetTopColor(_exploredColor);
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaceTowerRequest();        
        }        
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

    private void PlaceTowerRequest()
    {
        if (IsPathway || _containsTower)
        {
            print("Cannot place here");
        }
        else
        {
            PlaceTower();
        }
    }

    private void PlaceTower()
    {        
        if (_towerSpawner != null)
        {
            _containsTower = _towerSpawner.PlaceTower(transform.position);
        }
    }

}
