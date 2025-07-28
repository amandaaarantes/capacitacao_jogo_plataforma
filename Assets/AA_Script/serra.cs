using UnityEngine;

public class serra : MonoBehaviour
{

    public float speed;
    public float moveTime; // tempo de mov da serra
    public bool dirRight = true;
    private float timer;
    private HSistem hs;

    void Update()
    {
        if (dirRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); // vai pra direita
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime); //  vai pra esquerda
        }

        timer += Time.deltaTime; // retorna o tempo real no jg (deltaTime)
        if (timer >= moveTime)
        {
            dirRight = !dirRight;
            timer = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hs = collision.gameObject.GetComponent<HSistem>();
            if (hs != null)
            {
                hs.TakeDamage(hs.vida);
            }
            else
            {
                hs = collision.gameObject.GetComponentInParent<HSistem>();
                if (hs != null)
                {
                    hs.TakeDamage(hs.vida);
                }
            }
        }
    }
}
