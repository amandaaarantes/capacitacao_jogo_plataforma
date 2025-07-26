using Unity.VisualScripting;
using UnityEngine;

public class balas : MonoBehaviour
{

    public int damage = 1;
    public float tempoDestruicao = 3f;

    private HSistem alvo;

    void Start()
    {
        Destroy(gameObject, tempoDestruicao);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (!collision.CompareTag("Player"))
        {
            Debug.Log("Chegou no on trigger if");
            alvo = collision.GetComponent<HSistem>();
            if (alvo != null)
            {
                Debug.Log("Chegou no on trigger if if");
                alvo.TakeDamage(damage);
            }
            else
            {
               alvo = collision.GetComponentInParent<HSistem>();
            if (alvo != null)
            {
                Debug.Log("Chegou no on trigger if if if");
                alvo.TakeDamage(damage);
            } 
            }

            Destroy(gameObject);
        }
    }
}