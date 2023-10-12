using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawners : MonoBehaviour
{
    //https://docs.unity3d.com/ScriptReference/MonoBehaviour.StartCoroutine.html
    public GameObject[] prefabsToSpawn; // An array of prefabs to choose from.
    public Transform spawnPoint1;       // First spawn point.
    public Transform spawnPoint2;       // Second spawn point.
    public float minSpawnDelay = 2.0f;  // Minimum spawn delay in seconds.
    public float maxSpawnDelay = 5.0f;  // Maximum spawn delay in seconds.
    public Transform parentObject;      // The parent GameObject to which the spawned objects will be attached.

    private bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        // Start spawning objects with the defined delay.
        StartCoroutine(SpawnObjectWithRandomDelay());
    }

    IEnumerator SpawnObjectWithRandomDelay()
    {
        while (true)
        {
            if (canSpawn)
            {
                // Randomly choose one of the two spawn points.
                Transform spawnPoint = Random.Range(0, 2) == 0 ? spawnPoint1 : spawnPoint2;

                // Randomly select a prefab from the array.
                int randomIndex = Random.Range(0, prefabsToSpawn.Length);
                GameObject selectedPrefab = prefabsToSpawn[randomIndex];

                // Instantiate the selected prefab at the chosen spawn point's position and rotation, and make it a child of the parentObject.
                GameObject spawnedObject = Instantiate(selectedPrefab, spawnPoint.position, Quaternion.identity);
                spawnedObject.transform.parent = parentObject;

                // Generate a random spawn delay within the specified range.
                float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);

                // Prevent spawning for the duration of the random spawnDelay.
                canSpawn = false;
                yield return new WaitForSeconds(spawnDelay);
                canSpawn = true;
            }

            // Wait for the next spawn iteration.
            yield return null;
        }
    }   
}
