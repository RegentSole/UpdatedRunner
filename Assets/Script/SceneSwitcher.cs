using UnityEngine;
using UnityEngine.SceneManagement; // Подключаем SceneManager

public class SceneSwitcher : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}