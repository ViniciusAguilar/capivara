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
                    gameManager.instance.isBuildingMode = !gameManager.instance.isBuildingMode;

                    // Ativa ou desativa o fantasma
                    if (ghostBuilding != null)
                    {
                        ghostBuilding.SetActive(gameManager.instance.isBuildingMode);
                    }
                    Debug.Log("Modo de Construcao: " + (gameManager.instance.isBuildingMode ? "Ativado" : "Desativado"));
                }

                // A logica de construcao so funciona se o modo estiver ativado
                if (gameManager.instance.isBuildingMode)
                {
                    // Pega a posicao do mouse na tela
                    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mousePosition.z = 0; // Garante que o Z seja 0 para 2D

                    // Ajusta a posicao do mouse para o grid
                    Vector3 gridPosition = GridManager.instance.GetGridPosition(mousePosition);

                    // Move o objeto fantasma para a posicao ajustada do grid
                    if (ghostBuilding != null)
                    {
                        ghostBuilding.transform.position = gridPosition;
                    }

                    // Se o jogador clicar com o botao esquerdo, coloca a construcao
                    if (Input.GetMouseButtonDown(0))
                    {
                        Instantiate(buildingPrefab, gridPosition, Quaternion.identity);
                        Debug.Log("Construcao colocada em: " + gridPosition);
                    }
                }
            }       
}

