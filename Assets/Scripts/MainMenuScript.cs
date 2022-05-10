using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
