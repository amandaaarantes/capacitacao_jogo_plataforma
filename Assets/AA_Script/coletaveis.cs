using UnityEngine;

public class coletaveis : MonoBehaviour
{
    public int Score = 1;
    public float delay = 0;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameController.instance.totalScore += Score;
            gameController.instance.UpdateScoreText();
            Destroy(gameObject, delay);
        }
    }
}
