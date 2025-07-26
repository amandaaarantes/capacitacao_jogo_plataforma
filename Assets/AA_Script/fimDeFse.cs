using UnityEngine;

public class fimDeFse : MonoBehaviour
{
    public GameObject bandeira;
    public changeScenes cs;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("chegou no if da bandeira");
            cs.ChangeScene();
        }
    }
}
