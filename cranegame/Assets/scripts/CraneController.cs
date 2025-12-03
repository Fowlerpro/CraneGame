/* Ethan Gapic-Kott */

/// Script used for controlling crane movements (W,A,S,D)

using UnityEngine;

public class CraneController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 10f;

    [Header("Hover Indicator")]
    public Transform hoverIndicator;
    public float hoverOffset = 5f;

    void Start()
    {
        if (hoverIndicator != null)
            hoverIndicator.gameObject.SetActive(true);
    }

    void Update()
    {
        HandleMovement();
        UpdateHoverIndicator();
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0, z) * moveSpeed * Time.deltaTime;
        transform.position += move;
    }

    void UpdateHoverIndicator()
    {
        if (hoverIndicator == null) return;

        Vector3 pos = transform.position;
        pos.y = hoverOffset;
        hoverIndicator.position = pos;

        if (!hoverIndicator.gameObject.activeSelf)
            hoverIndicator.gameObject.SetActive(true);
    }
}
