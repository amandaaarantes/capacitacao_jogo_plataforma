using UnityEngine;
using System.Collections;

public class hits : MonoBehaviour
{

    [Header("Dano e Knockback")]
    public int damage = 1;
    public float knockbakForce = 5f;
    public float knockbackDelay = 1f;
    public enemyPatrol patrolCrabby;

    [Header("Animator")]
    public Animator animator;
    private void Start()
    {
        if (patrolCrabby == null)
        {
            Debug.Log("Patrol não foi atribuido");
        }
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Aplica dano
            HSistem hs = collision.GetComponent<HSistem>();
            if (hs != null)
            {
                hs.TakeDamage(damage);
                animator.SetTrigger("ataca");
            }

            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            if (playerRb != null && patrolCrabby != null)
            {
                Vector2 direcao = patrolCrabby.DirecaoMovimento;

                // Adiciona componente vertical pra criar a par�bola
                Vector2 knockbackDir = new Vector2(direcao.x, 1f).normalized;

                //StartCoroutine(AplicarKnockbackComDelay(playerRb, knockbackDir, knockbackDelay));

            }
        }
    }



}
