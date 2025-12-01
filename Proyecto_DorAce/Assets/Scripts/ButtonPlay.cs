using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Escena 1");
    }
}