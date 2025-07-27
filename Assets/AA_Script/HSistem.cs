using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HSistem : MonoBehaviour
{

    [Header("Vida")]
    public int vida = 5;
    public float tempoInvencibilidade = 1.5f;
    private bool estaInvencivel = false;

    [Header("Referência para a UI de vida")]
    public lifeUIController uiController;

    private Animator anim;


    public void TakeDamage(int amount)
    {
        anim = gameObject.GetComponent<Animator>();
        if (estaInvencivel)
            return;

        vida -= amount;
        
        anim.SetTrigger("dano");
        Debug.Log("Tomou dano! Vida restante: " + vida);

        // Atualiza a UI aqui se o objeto for o jogador
        if (CompareTag("Player") && uiController != null)
        {
            uiController.AtualizarCoracoes();
        }

        if (vida <= 0)
        {
            Debug.Log("Player morreu!");

            if (CompareTag("Player"))
            {
                anim.SetBool("morreu", true);
                Debug.Log("Player morreu! Aqui você pode chamar animação ou reiniciar a fase.");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            StartCoroutine(Invencibilidade());
        }


    }
    private IEnumerator Invencibilidade()
    {
        estaInvencivel = true;
        yield return new WaitForSeconds(tempoInvencibilidade);
        estaInvencivel = false;
    }


}