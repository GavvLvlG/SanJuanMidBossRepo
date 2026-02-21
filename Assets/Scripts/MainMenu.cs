using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        Debug.Log("New Game Start!");
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Debug.Log("quit!");
        Application.Quit();
    }
}
