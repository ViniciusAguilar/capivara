using UnityEngine;

public class GridManager : MonoBehaviour
{

    public static GridManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float cellSize = 1f;
    public int gridWidth = 16;
    public int gridHeight = 16;

    void Awake()
    {
        if (instance = null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Vector3 GetGridPosition(Vector3 worldPosition)
    {
        float x = Mathf.Floor(worldPosition.x / cellSize);
        float y = Mathf.Floor(worldPosition.y / cellSize);

        return new Vector3(x, y, 0);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;

        for (int x = 0; x <= gridWidth; x++)
        {
            Vector3 start = new Vector3(x * cellSize, 0, 0);
            Vector3 end = new Vector3(x * cellSize, gridHeight * cellSize, 0);
            Gizmos.DrawLine(start, end);
        }
        for (int y = 0; y <= gridHeight; y++)
        {
            Vector3 start = new Vector3(0, y * cellSize, 0);
            Vector3 end = new Vector3(gridWidth * cellSize, y * cellSize, 0);
            Gizmos.DrawLine(start, end);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
