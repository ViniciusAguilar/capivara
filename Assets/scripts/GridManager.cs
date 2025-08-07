using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;
    public float cellSize = 0.16f;
    public int gridWidth = 16;
    public int gridHeight = 16;

    // Objeto que serve como origem do grid (o canto inferior esquerdo)
    public Transform gridOriginObject;

    void Awake()
    {
        if (instance == null)
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
        Vector3 origin = (gridOriginObject != null) ? gridOriginObject.position : Vector3.zero;

        // Calcula a posicao relativa a origem do grid
        Vector3 localPosition = worldPosition - origin;

        // Alinha a posicao aos limites da celula e centraliza
        float x = Mathf.Floor(localPosition.x / cellSize) * cellSize + cellSize / 2f;
        float y = Mathf.Floor(localPosition.y / cellSize) * cellSize + cellSize / 2f;

        // Retorna a posicao final adicionando de volta a origem
        return new Vector3(x + origin.x, y + origin.y, 0);
    }
    public bool IsPositionInsideGrid(Vector3 worldPosition)
    {
        Vector3 origin = (gridOriginObject != null) ? gridOriginObject.position : Vector3.zero;

        // Calcula a posicao relativa a origem do grid
        Vector3 localPosition = worldPosition - origin;

        // A posicao da celula esta dentro dos limites do grid?
        return localPosition.x >= 0 && localPosition.x < gridWidth * cellSize &&
               localPosition.y >= 0 && localPosition.y < gridHeight * cellSize;
    }

    void OnDrawGizmos()
    {
        if (gridOriginObject == null)
        {
            return;
        }

        Vector3 gridOrigin = gridOriginObject.position;
        Gizmos.color = Color.gray;

        for (int x = 0; x <= gridWidth; x++)
        {
            Vector3 start = gridOrigin + new Vector3(x * cellSize, 0, 0);
            Vector3 end = gridOrigin + new Vector3(x * cellSize, gridHeight * cellSize, 0);
            Gizmos.DrawLine(start, end);
        }

        for (int y = 0; y <= gridHeight; y++)
        {
            Vector3 start = gridOrigin + new Vector3(0, y * cellSize, 0);
            Vector3 end = gridOrigin + new Vector3(gridWidth * cellSize, y * cellSize, 0);
            Gizmos.DrawLine(start, end);
        }
    }

}
