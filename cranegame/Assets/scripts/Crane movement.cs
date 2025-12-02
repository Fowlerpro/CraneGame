using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cranemovement : MonoBehaviour
{

    public float speed = 3;
    public float maxVelocity = 15;
    [SerializeField] private Rigidbody rb;


    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode forward = KeyCode.W;
    public KeyCode backward = KeyCode.S;
    public KeyCode up = KeyCode.Space;
    public KeyCode down = KeyCode.LeftControl;
    void FixedUpdate()
    {
        // Makes the player move left
        if (Input.GetKey(left))
        {
            // Cap movement speed
            bool canApplyVelocity = rb.velocity.magnitude < maxVelocity;
            if (canApplyVelocity)
            {
                Vector3 leftD = -transform.right * speed;
                rb.AddForce(leftD);
            }
        }
        if (Input.GetKey(right))
        {
            bool canApplyVelocity = rb.velocity.magnitude < maxVelocity;
            if (canApplyVelocity)
            {
                Vector3 rightD = transform.right * speed;
                rb.AddForce(rightD);
            }
        }

        // Add force to player
        if (Input.GetKey(forward))
        {
            // Cap movement speed
            bool canApplyVelocity = rb.velocity.magnitude < maxVelocity;
            if (canApplyVelocity)
            {
                Vector3 forwardD = transform.forward * speed;
                rb.AddForce(forwardD);
            }
        }
        if (Input.GetKey(backward))
        {
            // Cap movement speed
            bool canApplyVelocity = rb.velocity.magnitude < maxVelocity;
            if (canApplyVelocity)
            {
                Vector3 backwardD = -transform.forward * speed;
                rb.AddForce(backwardD);
            }
        }
        if (rb.transform.position.y <= 7)
        {
            if (Input.GetKey(up))
            {
                // Cap movement speed
                bool canApplyVelocity = rb.velocity.magnitude < maxVelocity;
                if (canApplyVelocity)
                {
                    Vector3 upD = transform.up * speed;
                    rb.AddForce(upD);
                }
            }
        }
        if (rb.transform.position.y >= 5)
        {
            if (Input.GetKey(down))
            {
                // Cap movement speed
                bool canApplyVelocity = rb.velocity.magnitude < maxVelocity;
                if (canApplyVelocity)
                {
                    Vector3 downD = -transform.up * speed;
                    rb.AddForce(downD);
                }
            }
        }
    }
}
