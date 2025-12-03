/* Ethan Gapic-Kott */

using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Objects to Spawn")]
    public GameObject[] obstaclePrefabs;

    [Header("Spawn Settings")]
    public float spawnIntervalMin = 1f;
    public float spawnIntervalMax = 3f;
    public float spawnXMin = 0f;
    public float spawnXMax = 0f;
    public float spawnYOffset = 6f;
    public float spawnZOffset = 50f;

    [Header("Multi-Spawn Settings")]
    public float delayBetweenExtraSpawns = 2f; // Delay between each object when multi-spawning

    [Header("References")]
    public Transform player;

    private float nextSpawnTime = 0f;
    private float startTime;


    void Start()
    {
        startTime = Time.time;
    }


    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            float elapsed = Time.time - startTime;

            // Normal mode (0–20s): 1 spawn
            // Mid mode (20–40s): 2 spawns
            // Hard mode (40s+): 3 spawns

            if (elapsed < 20f)
            {
                StartCoroutine(SpawnMulti(1));
            }
            else if (elapsed < 40f)
            {
                StartCoroutine(SpawnMulti(2));
            }
            else
            {
                StartCoroutine(SpawnMulti(3));
            }

            nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
        }
    }


    // Handles multi-spawns with delay
    private System.Collections.IEnumerator SpawnMulti(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnObject();
            yield return new WaitForSeconds(delayBetweenExtraSpawns);
        }
    }


    // Single spawn logic
    void SpawnObject()
    {
        if (obstaclePrefabs.Length == 0 || player == null) return;

        GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        float x = Random.Range(spawnXMin, spawnXMax);

        // Slight Z offset to prevent overlap when objects spawn rapidly
        float zOffsetFix = Random.Range(0.5f, 2f);

        Vector3 spawnPos = new Vector3(
            x,
            spawnYOffset,
            player.position.z + spawnZOffset + zOffsetFix
        );

        GameObject spawnedObj = Instantiate(prefab, spawnPos, Quaternion.identity);

        spawnedObj.AddComponent<ObstacleDespawner>().player = player;
    }
}



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
