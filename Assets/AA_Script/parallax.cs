using UnityEngine;

public class parallax : MonoBehaviour
{
    public Transform cameraJogador;
    private float startPos;
    private float startPosY;
    private float length;
    public float speedParallax;

    private float cameraStartY;


    void Start()
    {

        startPos = gameObject.transform.position.x;
        startPosY = gameObject.transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cameraStartY = cameraJogador.position.y;

    }

    void FixedUpdate()
    {
        float temp = (cameraJogador.position.x * (1 - speedParallax));
        float dist = (cameraJogador.position.x * speedParallax);
        float distY = ((cameraJogador.position.y - cameraStartY )* 1f);

        gameObject.transform.position = new Vector3(startPos + dist, startPosY + distY, cameraJogador.position.z);

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