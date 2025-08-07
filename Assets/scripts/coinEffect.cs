using UnityEngine;

public class coinEffect : MonoBehaviour
{
    public float speed = 1f;
    public float fadespeed =2f;
    public float lifeTime = 1f;

   
    private SpriteRenderer spriteRenderer;
    private float currentLife;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentLife = lifeTime;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);



        currentLife -= Time.deltaTime;
        if (currentLife <= 0)
        {
            if (spriteRenderer != null)
            {
            Color spriteColor = spriteRenderer.color;
            spriteColor.a = fadespeed * Time.deltaTime;
            spriteColor.a = Mathf.Clamp(spriteColor.a, 0, 1f);
            spriteRenderer.color = spriteColor;
            }
            Destroy(gameObject);
        }
    }
}
