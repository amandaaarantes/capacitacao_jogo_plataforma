using UnityEngine;

public class footPatrol : MonoBehaviour
{
    public Transform transformDoInimgo;
    public RigidBody2D rbInimigo;
    public float moveSpeed = 2f;
    public LayerMask groundLayer;

    private bool estaNoGround = true;
    private Vector2 moveDirection = Vestor2.right;

    private void Start()
    {
        if (transformDoInimgo == null)
            transformDoInimgo = transform.parent;
        if (rbInimigo == null)
            rbInimigo = transformDoInimgo.GetComponent<RigidBody2D>();
    }

    private void FixedUpdate()
    {
        rbInimigo.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rbInimigo.linearVelocity.y);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        moveDirection = -moveDirection;

        Vector3 scale = transformDoInimgo.localScale;
        scale.x *= -1;
        enemyTransform.localScale = scale;
    }

}