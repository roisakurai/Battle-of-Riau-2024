using UnityEngine;
using System.Collections;

public class ShipSpawnerScene31 : MonoBehaviour
{
    public TMPro.TextMeshProUGUI waveText;
    public WaveInfo[] waves;
    public float waveInterval;
    public float textDelay;
    public float spawnInterval;
    public float spawnPositionX;
    public float spawnPositionY;
    public float spawnPositionZ;
    public float initialDelay;
    private int currentSpawnCount;

    private void Start()
    {
        StartCoroutine(InitializeWaves());
    }

    private IEnumerator InitializeWaves()
    {
        yield return new WaitForSeconds(initialDelay);
        StartCoroutine(StartWaves());
    }

    private IEnumerator StartWaves()
    {
        yield return new WaitForSeconds(waveInterval);

        for (int waveIndex = 0; waveIndex < waves.Length; waveIndex++)
        {
            WaveInfo wave = waves[waveIndex];

            yield return StartCoroutine(ShowWaveText("Wave " + (waveIndex + 1), textDelay));

            yield return new WaitForSeconds(waveInterval);

            yield return StartCoroutine(SpawnWave(wave.prefab, wave.count, spawnInterval, new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ)));

            yield return new WaitForSeconds(waveInterval);
        }
    }

    private IEnumerator ShowWaveText(string text, float delay)
    {
        waveText.text = text;
        yield return new WaitForSeconds(delay);
        waveText.text = "";
    }

    private IEnumerator SpawnWave(GameObject prefab, int count, float interval, Vector3 spawnPosition)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(prefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }

    public int GetCurrentSpawnCount()
    {
        return currentSpawnCount;
    }
}
