/* Ethan Gapic-Kott */

using UnityEngine;

public class InfiniteGround : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float tileLength = 200f;

    // Loops ground objects creating infinite runner
    void Update()
    {
        if (player.position.z > transform.position.z + tileLength)
        {
            transform.position += new Vector3(0, 0, tileLength * 2f);
        }
    }
}
