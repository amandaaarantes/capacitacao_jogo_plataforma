using UnityEngine;

public class coletaveis : MonoBehaviour
{
    public int Score = 1;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameController.instance.totalScore += Score;
            gameController.instance.UpdateScoreText();
            Destroy(gameObject);
        }
    }
}
