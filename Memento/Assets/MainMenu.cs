using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Tutorial_1");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Player Has Quit The Game");
    }
}
