/* Ethan Gapic-Kott */

using UnityEngine;

public class ObjectCollisionTrigger : MonoBehaviour
{
    [Header("UI Settings")]
    public GameObject gameOverPanel; // UI panel to show on collision
    public bool stopTimeOnGameOver = true;

    void OnCollisionEnter(Collision collision)
    {
        // Only trigger if colliding with player
        if (collision.gameObject.CompareTag("Player"))
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (stopTimeOnGameOver)
        {
            Time.timeScale = 0f;
        }
    }
}
