using UnityEngine;

public class atiradorJogador : MonoBehaviour
{

    [Header("Referências")]
    public GameObject tiroPrefab;
    public Transform pontoDisparo; // local de onde sai o tiro

    [Header("Configuração")]
    public float velocidadeTiro = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // botão esquerdo do mouse
        {
            atirar();
        }
    }

    void atirar()
    {
        GameObject tiro = Instantiate(tiroPrefab, pontoDisparo.position, Quaternion.identity);

        Rigidbody2D rb = tiro.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            float direcao = Mathf.Sign(transform.localScale.x);
            rb.linearVelocity = new Vector2(direcao * velocidadeTiro, 0f);

            Vector3 escalaTiro = tiro.transform.localScale;
            escalaTiro.x *= direcao;
            tiro.transform.localScale = escalaTiro;
        }
    }

}