using UnityEngine;
using System.Collections;

public class SoldierSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int numberToSpawn = 1;
    public int totalSpawnLimit = 10;
    public float spawnRadius = 4f;
    public float spawnDelay = 5f;
    public float initialDelay = 7f;
    private int currentSpawnCount;

    void Start()
    {
        StartCoroutine(InitialDelayCoroutine());
    }

    IEnumerator InitialDelayCoroutine()
    {
        yield return new WaitForSeconds(initialDelay);
        StartCoroutine(SpawnSoldiersCoroutine());
    }

    IEnumerator SpawnSoldiersCoroutine()
    {
        while (currentSpawnCount < totalSpawnLimit)
        {
            for (int i = 0; i < numberToSpawn; i++)
            {
                SpawnObject();
            }
            currentSpawnCount++;

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnObject()
    {
        GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        Vector3 randomOffset = Random.onUnitSphere * spawnRadius * Random.Range(0f, 1f);
        randomOffset.y = 0f;

        Vector3 spawnPosition = transform.position + randomOffset;

        Instantiate(randomEnemyPrefab, spawnPosition, Quaternion.identity);
    }

    public int GetCurrentSpawnCount()
    {
        return currentSpawnCount;
    }
}
