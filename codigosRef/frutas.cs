using UnityEngine;

public class frutas : MonoBehaviour
{
    public int valor = 1;
    public GameObject frutaPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Fruit"))
        {
            
    }
}
