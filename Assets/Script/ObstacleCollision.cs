using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject defeatCanvas; // Ссылка на Canvas с сообщением о поражении

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ActivateDefeatCanvas();
            GameManager.PauseGame(); // Ставим игру на паузу
        }
    }

    private void ActivateDefeatCanvas()
    {
        defeatCanvas.SetActive(true); // Активируем Canvas
    }
}