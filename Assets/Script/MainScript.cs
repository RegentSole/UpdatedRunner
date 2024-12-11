using UnityEngine;

public static class GameManager
{
    public static bool IsPaused { get; private set; } = false;

    public static void PauseGame()
    {
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1f;
        IsPaused = false;
    }
}