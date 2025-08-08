using UnityEngine;

public class coco : MonoBehaviour
{
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public int xpToGive = 10;

    public GameObject moeda;

    void Start()
    {
        Debug.Log("Script do Coco inicializado.");
        
    
    }


    void OnMouseDown()
    {
        if (gameManager.instance != null)
        {
            gameManager.instance.AddCoinsAndXp(gameManager.instance.cocoPriceTotal, xpToGive, xpToGive);

        }
        if (moeda != null)
        {
            Instantiate(moeda, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
        
    }

}
