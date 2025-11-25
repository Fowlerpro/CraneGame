using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score;
    public Transform player;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update

    private void Awake()
    {
        score = 0;
        StartCoroutine(IncreaseScore());
    }

    void Update()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = "SCORE:" + score;
    }

    IEnumerator IncreaseScore()
    {
        while (true)
        {
            score += 10;
            yield return new WaitForSeconds(1);
        }
    }
}
