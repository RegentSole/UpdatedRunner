using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void RestartScene()
    {
        GameManager.ResumeGame(); // Возобновляем игру перед перезагрузкой
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}