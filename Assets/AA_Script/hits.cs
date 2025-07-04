using UnityEngine;
using System.Collections;

public class hits : MonoBehaviour
{

    [Header("Dano e Knockback")]
    public int damage = 1;
    public float knockbakForce = 5f;
    public float knockbackDelay = 1f;
    public enemyPatrol patrol;

    private void Start()
    {
        if (patrol == null)
        {
            Debug.Log("Patrol não foi atribuido");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Aplica dano
            healthSystem hs = collision.GetComponent<healthSystem>();
            if (hs != null)
            {
                hs.TakeDamage(damage);
            }

            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            if (playerRb != null && patrol != null)
            {
                Vector2 direcao = patrol.DirecaoMovimento.normalized;

                // Adiciona componente vertical pra criar a par�bola
                Vector2 knockbackDir = new Vector2(direcao.x, 1f).normalized;

                StartCoroutine(AplicarKnockbackComDelay(playerRb, knockbackDir, knockbackDelay));

            }
        }
    }



}
