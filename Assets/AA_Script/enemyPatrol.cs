 using UnityEngine;

public class enemyPatrol : MonoBehaviour

{
    private Rigidbody2D enemyRb;
    public float moveSpeed = 2f;

    public BoxCollider2D pe;      // Colisor do pé (verifica se tem chão à frente)
    public BoxCollider2D frente;  // Colisor da frente (verifica colisão com o que vem pela frente)

    private Vector2 moveDirection = Vector2.right;

    public Vector2 DirecaoMovimento => moveDirection;


    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        enemyRb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, enemyRb.linearVelocity.y);
    }

    public void Flip()
    {
        moveDirection *= -1;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}