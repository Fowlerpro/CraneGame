/* Ethan Gapic-Kott */

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1f; // Restarts the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // stop in editor
#else
        Application.Quit(); // Quits application
#endif
    }
}
