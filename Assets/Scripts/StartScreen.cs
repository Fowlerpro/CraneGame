using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public GameObject startImage;  // Start Image
    public bool gameStarted = false;

    void Start()
    {
        // Freeze game
        Time.timeScale = 0f;
        startImage.SetActive(true);
    }

    void Update()
    {
        if (!gameStarted && Input.anyKey)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        gameStarted = true;
        startImage.SetActive(false);

        Time.timeScale = 1f;  // Unfreeze the game
    }
}
