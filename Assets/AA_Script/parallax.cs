using UnityEngine;

public class parallax : MonoBehaviour
{
    public GameObject cameraJogador;
    private float startPos;
    private float length;
    public float speedParallax;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    void FixedUpdate()
    {
        float temp = (cameraJogador.transform.position.x * (1 - speedParallax));
        float dist = (cameraJogador.transform.position.x * speedParallax);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

       if (temp > startPos + length)
        {
            startPos += length;
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }
    }
}