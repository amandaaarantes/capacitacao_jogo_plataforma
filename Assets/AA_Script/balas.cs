using UnityEngine;

public class balas : MonoBehaviour
{

    public int damage = 1;
    public float tempoDestruicao = 3f;

    void Start()
    {
        Destroy(gameObject, tempoDestruicao);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.CompareTag("Player"))
        {
            HSistem alvo = collision.GetComponent<HSistem>();
            if (alvo != null)
            {
                alvo.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}