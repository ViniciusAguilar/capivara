using UnityEngine;

public class gameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static gameManager instance;
    public int coins = 10;
    public int xp = 0;
    public int cocoPriceTotal = 1;
    public int n_capivaras = 0;
    public int max_capivaras = 1;

    public bool isBuildingMode= false;

    private Animator _animator;

    public GameObject capivara;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoinsAndXp(int coinsAdd, int xpAdd)
    {
        coins += coinsAdd;
        xp += xpAdd;
        Debug.Log("Você ganhou " + coinsAdd + " moedas e " + xpAdd + " XP!!");
        Debug.Log("Total de moedas: " + coins + " Total Xp" + xp);
    }
    void Update()
    {
        // Desenha um raio de onde o mouse está clicando
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.DrawRay(mousePosition, Vector3.forward, Color.red, 1f);
        }

    }
    void OnMouseEnter()
    {
        _animator.SetBool("mouseIn", true);
    }

    void OnMouseExit()
    {
        _animator.SetBool("mouseIn", false);
    }

    void OnMouseDown()
    {
        if (n_capivaras < max_capivaras && coins >= 10)
        {
            Instantiate(capivara,new Vector3(0, 0, 0), Quaternion.identity);
            coins -= 10;
            n_capivaras += 1;
        }
    }
}
