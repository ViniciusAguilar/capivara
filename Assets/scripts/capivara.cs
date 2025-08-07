using UnityEngine;

public class capivara : MonoBehaviour
{
    //Movimento

    public float speed = 0.2f;
    public float changeDirectionTime = 2f;
    public Vector2 direcao;
    private float lastChangeTime;

    private Animator _animator;

    private Rigidbody2D _rb;


    //Criação de coco

    public GameObject coco;
    public float poopTime = 5f;
    public float currentPoopTime;
    private int poopPrice = 1;


    public float randNum;

    // evolução

    public int xpParaEvoluir = 100;
    private bool jaEvoluiu = false;

    private SpriteRenderer spriteRenderer;

    public Sprite[] adultSprites;

    void Start()
    {
        lastChangeTime = Time.time;
        _animator = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        choose_new_direction();
        gameManager.instance.cocoPriceTotal = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastChangeTime > changeDirectionTime)
        {
            choose_new_direction();
            lastChangeTime = Time.time;
        }
        //transform.Translate(direcao * speed * Time.deltaTime);

        currentPoopTime += Time.deltaTime;

        if (currentPoopTime >= poopTime)
        {

            Instantiate(coco, transform.position, Quaternion.identity);
            currentPoopTime = 0;
        }
        if (jaEvoluiu == false && gameManager.instance.xp >= xpParaEvoluir)
        {
            evoluir_capivara();
        }
    }

    void FixedUpdate()
    {
        _rb.linearVelocity = direcao * speed;
    }

    void choose_new_direction()
    {

        bool isMoving = Random.Range(0f, 1f) > 0.3f;
        if (isMoving)
        {
            randNum = Random.Range(1, 5);

            switch (randNum)
            {
                case 1:
                    direcao = Vector2.right;
                    break;
                case 2:
                    direcao = Vector2.left;
                    break;
                case 3:
                    direcao = Vector2.up;
                    break;
                case 4:
                    direcao = Vector2.down;
                    break;
            }

            // direcao = Random.insideUnitCircle.normalized;
            _animator.SetBool("isWalking", true);
        }
        else
        {
            direcao = Vector2.zero;
            _animator.SetBool("isWalking", false);
        }

    }

    void evoluir_capivara()
    {
        gameManager.instance.cocoPriceTotal = 2;
        if (jaEvoluiu == false)
        {
            jaEvoluiu = true;
            if (spriteRenderer != null && adultSprites.Length > 0)
            {
                int randomIndex = Random.Range(0, adultSprites.Length);
                spriteRenderer.sprite = adultSprites[randomIndex];
                
            }
        }
    }

}   
