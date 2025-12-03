/* Ethan Gapic-Kott */

using UnityEngine;

public class MagnetController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 10f;
    public float sprintMultiplier = 2f;
    public float verticalSpeed = 6f;
    public float minHeight = 3f;
    public float maxHeight = 12f;
    public KeyCode sprintKey = KeyCode.LeftShift;





    void Start()
    {
        // Ignore collision with player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Collider magnetCollider = GetComponent<Collider>();
            Collider playerCollider = player.GetComponent<Collider>();
            if (magnetCollider != null && playerCollider != null)
                Physics.IgnoreCollision(magnetCollider, playerCollider);
        }
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float currentSpeed = moveSpeed;
        if (Input.GetKey(sprintKey))
            currentSpeed *= sprintMultiplier;

        // Horizontal movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(x, 0, z) * currentSpeed * Time.deltaTime;

        // Vertical movement
        float newY = transform.position.y;
        if (Input.GetKey(KeyCode.Q)) newY += verticalSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.E)) newY -= verticalSpeed * Time.deltaTime;
        newY = Mathf.Clamp(newY, minHeight, maxHeight);

        transform.position += move;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

}
