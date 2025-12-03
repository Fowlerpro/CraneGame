using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    [Header("Pickup Settings")]
    public Transform pickUpPoint;
    public float pickupRange = 1.5f;
    public KeyCode pickupKey = KeyCode.Space;
    private Rigidbody heldMetal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandlePickupAndDrop();
        MoveHeldMetal();
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
