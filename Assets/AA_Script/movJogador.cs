using UnityEngine;

public class movJogador : MonoBehaviour
{

    [Header("Movimentação")]
    public float speed = 5f;

    [Header("Pulo")]
    public float jumpForce = 10f;
    public int quantPulosExtras = 2;
    private int pulosRestantes;

    [Header("Verificação do Chão")]
    public float raioGroundCheck = 0.2f;
    private bool estaNoGround;
    public LayerMask groundLayer;
    public Transform groundCheck;


    public Rigidbody2D rb;
    private float moveInput;
    private Animator animatorJogador;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorJogador = GetComponent<Animator>();
        pulosRestantes = quantPulosExtras;
    }

    void Update()
    {
        // ler movimentação em x
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);


        // verifica se esta andando e ativa o flip
        if (moveInput != 0)
        {
            animatorJogador.SetBool("estaCorrendo", true);
            flip(moveInput);
        }
        else
        {
            animatorJogador.SetBool("estaCorrendo", false);
        }

        // verifica se esta no chão
        estaNoGround = Physics2D.OverlapCircle(groundCheck.position, raioGroundCheck, groundLayer);
        // Cria um círculo invisível na posição do "groundCheck" com o raio definido. Se esse círculo colidir com qualquer objeto na camada "groundLayer", isGrounded se torna 'true'.
        animatorJogador.SetBool("estaNoChao", estaNoGround);

        if (estaNoGround)
        {
            pulosRestantes = quantPulosExtras;
        }

        // faz pular
        if (Input.GetButtonDown("Jump") && pulosRestantes > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            pulosRestantes--;
            animatorJogador.SetTrigger("Pulando");
        }

        // restante do animator:
        animatorJogador.SetFloat("VelocidadeX", Mathf.Abs(moveInput));
        animatorJogador.SetFloat("VelocidadeY", rb.linearVelocity.y);
    }

    void flip(float direcao)
    {
        transform.localScale = new Vector3(Mathf.Sign(direcao), 1f, 1f);
    }
}
