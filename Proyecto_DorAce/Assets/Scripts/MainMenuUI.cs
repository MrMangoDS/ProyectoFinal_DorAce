using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuUI : MonoBehaviour
{
   
    public void StartNewGame()
    {
        SceneManager.LoadScene("Escena 1");
    }

    public void LoadSavedGamesMenu()
    {
        SceneManager.LoadScene("Load Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

}