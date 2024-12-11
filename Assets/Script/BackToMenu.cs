using UnityEngine;
using UnityEngine.SceneManagement; // Подключаем SceneManager

public class BackToMenu : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}