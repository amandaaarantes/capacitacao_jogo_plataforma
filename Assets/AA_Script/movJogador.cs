using System.Collections;
using Unity.VisualScripting;
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
    public float raioWallCheck = 0.2f;
    private bool estaNoGround;
    private bool estaNaWall;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public Transform wallCheck;
    public Rigidbody2D rb;

    private float moveInput;
    private Animator animatorJogador;

    [Header("Dashing")]
    public float dashPower = 20f;
    public float dashTime = 0.2f;
    private bool canDash = true;
    private bool isDashing;
    private float dashCooldown = 1f;

    // public TrailRenderer tr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorJogador = GetComponent<Animator>();
        pulosRestantes = quantPulosExtras;
        

    }

    void Update()
    {

        if (isDashing)
        {
            return; //impede o movimento durante o dash!
        }
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
        //verifica se esta na parede
        estaNaWall = Physics2D.OverlapCircle(wallCheck.position, raioWallCheck, groundLayer);
        // Cria um círculo invisível na posição do "groundCheck" com o raio definido. Se esse círculo colidir com qualquer objeto na camada "groundLayer", isGrounded se torna 'true'.
        animatorJogador.SetBool("estaNoChao", estaNoGround);
        animatorJogador.SetBool("estaNaParede", estaNaWall);

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

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    void flip(float direcao)
    {
        transform.localScale = new Vector3(Mathf.Sign(direcao), 1f, 1f);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(transform.localScale.x * dashPower, 0f);
        //tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        //tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

    }
}
