using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class lifeUIController : MonoBehaviour
{
    [Header("Referências")]
    public GameObject heartFullPrefab;
    public GameObject heartEmptyPrefab;
    public Transform heartParent;
    public HSistem healthSystem;

    private List<GameObject> heartObjects = new List<GameObject>();

    public void Start()
    {
        AtualizarCoracoes();
    }

    public void AtualizarCoracoes()
    {
        int maxVidas = healthSystem.vida;
        int vidasAtuais = healthSystem.vida;

        // Se já tiver corações instanciados, destrói todos para recriar corretamente
        foreach (GameObject heart in heartObjects)
        {
            Destroy(heart);
        }
        heartObjects.Clear();

        // Instancia corações conforme vidas
        for (int i = 0; i < maxVidas; i++)
        {
            GameObject heartPrefab = (i < vidasAtuais) ? heartFullPrefab : heartEmptyPrefab;
            GameObject heart = Instantiate(heartPrefab, heartParent);
            heartObjects.Add(heart);
        }
    }
}