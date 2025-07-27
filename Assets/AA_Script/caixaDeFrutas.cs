using System;
using Unity.VisualScripting;
using UnityEngine;

public class caixaDeFrutas : MonoBehaviour
{
    public GameObject abacaxi1;
    public GameObject abacaxi2;
    public GameObject abacaxi3;

    public void Start()
    {
        abacaxi1.SetActive(false);
        abacaxi2.SetActive(false);
        abacaxi3.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            abacaxi1.SetActive(true);
            abacaxi2.SetActive(true);
            abacaxi3.SetActive(true);
        }
    }
}
