/* Ethan Gapic-Kott */

using TMPro;
using UnityEngine;

public class RunnerUI : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;

    float startZ;
    float timeElapsed;

    void Start()
    {
        startZ = player.position.z;
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        int distance = Mathf.FloorToInt(player.position.z - startZ);
        scoreText.text = "Distance: " + distance + "m";
    }
}
