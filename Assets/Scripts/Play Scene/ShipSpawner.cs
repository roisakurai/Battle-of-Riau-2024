using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShipSpawner : MonoBehaviour
{
    private TMPro.TextMeshProUGUI waveText => VariableManager.instance.waveText;
    private WaveInfo[] waves => VariableManager.instance.waves;
    private float waveInterval => VariableManager.instance.waveInterval;
    private float textDelay => VariableManager.instance.textDelay;
    private float spawnInterval => VariableManager.instance.spawnInterval;
    private float spawnPositionX => VariableManager.instance.spawnPositionX;
    private float spawnPositionY => VariableManager.instance.spawnPositionY;
    private float spawnPositionZ => VariableManager.instance.spawnPositionZ;
    private float initialDelay => VariableManager.instance.initialDelay;

    private void Start()
    {
        StartCoroutine(InitializeSpawning());
    }

    private IEnumerator InitializeSpawning()
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

            yield return StartCoroutine(SpawnWave(wave.prefab, wave.count, spawnInterval));

            yield return new WaitForSeconds(waveInterval);
        }
    }

    private IEnumerator ShowWaveText(string text, float delay)
    {
        waveText.text = text;
        yield return new WaitForSeconds(delay);
        waveText.text = "";
    }

    private IEnumerator SpawnWave(GameObject prefab, int count, float interval)
    {
        Vector3 spawnPosition = new(spawnPositionX, spawnPositionY, spawnPositionZ);

        for (int i = 0; i < count; i++)
        {
            Instantiate(prefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }
}
