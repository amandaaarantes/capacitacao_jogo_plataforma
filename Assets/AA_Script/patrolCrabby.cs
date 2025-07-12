using UnityEngine;

public class patrolCrabby : MonoBehaviour
{

    public Transform enemyTransform; // arraste o inimigo aqui no inspetor
    public Rigidbody2D enemyRb;      // arraste o Rigidbody2D do inimigo
    public float moveSpeed = 2f;
    public LayerMask groundLayer;
    public LayerMask wallLayer;

    [Header("Configuração do Detector")]
    public bool isFront; 
    public bool isFoot; 
    public Vector2 moveDirection = Vector2.right;


    void Start()
    {
        if (enemyTransform == null)
            enemyTransform = transform.parent;

        if (enemyRb == null)
            enemyRb = enemyTransform.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        enemyRb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, enemyRb.linearVelocity.y);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0 && isFoot)
        {
            Flip();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & wallLayer) != 0 && isFront)
        {
            Flip();
        }
    }

   private void Flip()
{
    moveDirection *= -1; 

    // O que você quer: "Pegue a escala do 'enemyTransform' (o próprio Crabby)"
    Vector3 scale = enemyTransform.localScale; // <-- A correção está aqui
    scale.x *= -1;
    
    // O que você quer: "Aplique a nova escala no 'enemyTransform' (o próprio Crabby)"
    enemyTransform.localScale = scale; // <-- E aqui
}
}
