/* Ethan Gapic-Kott */

using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Objects to Spawn")]
    public GameObject[] obstaclePrefabs; // Obstacle Prefabs

    [Header("Spawn Settings")]
    public float spawnIntervalMin = 10f; // Seconds until an object spawns
    public float spawnIntervalMax = 3f;
    public float spawnXMin = 0f;
    public float spawnXMax = 0f;
    public float spawnYOffset = 6f;      // Spawn Height
    public float spawnZOffset = 50f;     // Distance infront of the Player

    [Header("References")]
    public Transform player;

    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
        }
    }

    // Spawns a prefab at random, and destroys it when passed by the player

    /// <summary>
    ///  TODO, When crane is functional, colliding with the object prefabs will cause the player to lose the game
    /// </summary>
    /// 
    void SpawnObject()
    {
        if (obstaclePrefabs.Length == 0 || player == null) return;
        GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        float x = Random.Range(spawnXMin, spawnXMax);

        Vector3 spawnPos = new Vector3(x, spawnYOffset, player.position.z + spawnZOffset);
        GameObject spawnedObj = Instantiate(prefab, spawnPos, Quaternion.identity);
        spawnedObj.AddComponent<ObstacleDespawner>().player = player;
    }
}

// Despawns object when the player passes
public class ObstacleDespawner : MonoBehaviour
{
    [HideInInspector] public Transform player;

    void Update()
    {
        if (player != null && player.position.z > transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}
