using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScenes : MonoBehaviour
{

    [Header("Nome da próxima cena")]
    public string nextScene;

    public void ChangeScene()
    {
        if (!string.IsNullOrEmpty(nextScene))
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            Debug.LogWarning("O nome da próxima cena não foi definido.");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }

}