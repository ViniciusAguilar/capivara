using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject buildingPrefab;
    public GameObject ghostBuilding;

    void Start()
    {
        if (buildingPrefab != null)
        {
            ghostBuilding = Instantiate(buildingPrefab);
            if (ghostBuilding.GetComponent<SpriteRenderer>() != null)
            {
                Color ghostColor = ghostBuilding.GetComponent<SpriteRenderer>().color;
                ghostColor.a = 0.5f; // 50% de transparencia
                ghostBuilding.GetComponent<SpriteRenderer>().color = ghostColor;
            }
            ghostBuilding.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (gameManager.instance != null)
            {
                gameManager.instance.isBuildingMode = !gameManager.instance.isBuildingMode;
                if (ghostBuilding != null)
                {
                    ghostBuilding.SetActive(gameManager.instance.isBuildingMode);
                }
                Debug.Log("Modo de Construcao: " + (gameManager.instance.isBuildingMode ? "Ativado" : "Desativado"));
            }
        }

        if (gameManager.instance != null && gameManager.instance.isBuildingMode)
        {
            if (GridManager.instance != null && Camera.main != null)
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = Camera.main.transform.position.z;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

                Vector3 gridPosition = GridManager.instance.GetGridPosition(worldPosition);

                // NOVO: Verifica se a posicao é valida
                bool isValidPosition = GridManager.instance.IsPositionInsideGrid(worldPosition);

                if (ghostBuilding != null)
                {
                    ghostBuilding.transform.position = gridPosition;

                    // Muda a cor do fantasma para indicar se a posicao é valida ou nao
                    SpriteRenderer ghostRenderer = ghostBuilding.GetComponent<SpriteRenderer>();
                    if (ghostRenderer != null)
                    {
                        ghostRenderer.color = isValidPosition ? new Color(0, 1, 0, 0.5f) : new Color(1, 0, 0, 0.5f);
                    }
                }

                // Apenas constroi se a posicao for valida e o jogador clicar
                if (isValidPosition && Input.GetMouseButtonDown(0))
                {
                    Instantiate(buildingPrefab, gridPosition, Quaternion.identity);
                    Debug.Log("Construcao colocada em: " + gridPosition);
                }
            }
        }
    }
    }

