/* Ethan Gapic-Kott */

using UnityEngine;

public class PlayerForward : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 10f;

    void Update()
    {
        // Infinitely moves the player forward
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }
}
