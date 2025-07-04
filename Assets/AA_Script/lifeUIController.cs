using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class lifeUIController : MonoBehaviour
{
    [Header("Referências")]
    public GameObject heartFull;
    public GameObject hearthEmpty;
    public Transform heartParent;
    public healthSistem hs;

    private List<GameObject> heartObjects = new List<GameObject>();

    void Start()
    {
        atualizaCoracoes();
    }
    void Update()
    {

    }

    public void atualizaCoracoes()
    {
        int maxVidas = hs.vida;
        int vidasAtuais = hs.vida;

        foreach (GameObject heart in heartObjects)
        {
            Destroy(heart);
        }
        heartObjects.Clear();

        for (int i = 0; i < maxVidas; i++)
        {
            GameObject heartPrefab = (i < vidasAtuais) ? heartFull : heartEmpty;
            GameObject heart = Instantiate(heartPrefab, heartParent);
            heartObjects.Add(heart);
        }
        
    }

}