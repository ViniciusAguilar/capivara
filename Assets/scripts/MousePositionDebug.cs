using UnityEngine;

public class MousePositionDebug : MonoBehaviour
{
       void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        // Converte a posicao do mouse da tela para o mundo, garantindo a coordenada Z correta
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.z));

        // Define a posicao do objeto para a posicao do mouse no mundo
        transform.position = new Vector3(worldPosition.x, worldPosition.y, 0);
    }
}
