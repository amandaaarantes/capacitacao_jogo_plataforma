using UnityEngine;

public class ataqueDeCimaJogador : MonoBehaviour
{
    public int dano = 1;
    private HSistem alvo; 
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            alvo = collision.GetComponentInParent<HSistem>();
            if (alvo != null)
            {
                alvo.TakeDamage(dano);
            }
        }
    }
}
