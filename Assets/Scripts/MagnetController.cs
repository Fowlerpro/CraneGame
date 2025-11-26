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

    [Header("Pickup Settings")]
    public Transform pickUpPoint;
    public float pickupRange = 1.5f;
    public KeyCode pickupKey = KeyCode.Space;

    private Rigidbody heldMetal;

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
        HandlePickupAndDrop();
        MoveHeldMetal();
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

    void HandlePickupAndDrop()
    {
        if (Input.GetKeyDown(pickupKey))
        {
            if (heldMetal == null)
            {
                // Pick up nearest metal below pickUpPoint
                Collider[] hits = Physics.OverlapSphere(pickUpPoint.position, pickupRange);
                foreach (Collider col in hits)
                {
                    if (col.CompareTag("Metal") && col.attachedRigidbody != null)
                    {
                        if (col.transform.position.y <= pickUpPoint.position.y)
                        {
                            heldMetal = col.attachedRigidbody;
                            heldMetal.useGravity = false;
                            heldMetal.velocity = Vector3.zero;
                            heldMetal.angularVelocity = Vector3.zero;
                            heldMetal.transform.position = pickUpPoint.position;
                            heldMetal.transform.SetParent(pickUpPoint);
                            break;
                        }
                    }
                }
            }
            else
            {
                // Drop metal
                heldMetal.transform.SetParent(null);
                heldMetal.useGravity = true;
                heldMetal = null;
            }
        }
    }

    void MoveHeldMetal()
    {
        if (heldMetal != null)
            heldMetal.transform.position = pickUpPoint.position;
    }

    private void OnDrawGizmosSelected()
    {
        if (pickUpPoint != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(pickUpPoint.position, pickupRange);
        }
    }
}
