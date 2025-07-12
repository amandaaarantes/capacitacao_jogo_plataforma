using UnityEngine;
using UnityEngine.UIElements;

public class footPatrol : MonoBehaviour
{
    public Transform transformDoInimgo;
    public Rigidbody2D rbInimigo;
    public float moveSpeed = 2f;
    public LayerMask groundLayer;

    public bool isFoot;
    public bool isFront;

    public Transform groundCheck; 
    public Transform wallCheck;

    private Vector2 moveDirection = Vector2.right;

    public Vector2 DirecaoMovimento => moveDirection;

    private void Start()
    {
        if (transformDoInimgo == null)
            transformDoInimgo = transform.parent;
        if (rbInimigo == null)
            rbInimigo = transformDoInimgo.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rbInimigo.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rbInimigo.linearVelocity.y);
        isFoot = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        isFront = Physics2D.OverlapCircle(wallCheck.position, 0.2f, groundLayer);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isFoot &&((1 <<collision.gameObject.layer) & groundLayer) != 0)
            Flip();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFront && ((1 <<collision.gameObject.layer) & groundLayer) != 0)
            Flip();
    }

    private void Flip()
    {
        moveDirection = -moveDirection;

        Vector3 scale = transformDoInimgo.localScale;
        scale.x *= -1;
        transformDoInimgo.localScale = scale;

    }
}

