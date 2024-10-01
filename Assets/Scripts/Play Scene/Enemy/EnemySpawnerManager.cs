using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnerManager : MonoBehaviour
{
    public List<GameObject> spawners; // Daftar gameobject spawner yang diatur
    private int currentSpawnerIndex = 0;

    void Start()
    {
        // Pastikan semua spawner dimatikan pada awalnya
        foreach (GameObject spawner in spawners)
        {
            spawner.SetActive(false);
        }

        // Aktifkan spawner pertama
        if (spawners.Count > 0)
        {
            ActivateSpawner(currentSpawnerIndex);
        }
    }

    void ActivateSpawner(int index)
    {
        if (index < spawners.Count)
        {
            spawners[index].SetActive(true); // Aktifkan spawner
            SoldierSpawner spawnerScript = spawners[index].GetComponent<SoldierSpawner>();
            
            // Jalankan coroutine untuk menunggu sampai spawner selesai memunculkan semua musuh
            StartCoroutine(WaitForSpawnerToFinish(spawnerScript, index));
        }
    }

    IEnumerator WaitForSpawnerToFinish(SoldierSpawner spawnerScript, int index)
    {
        // Tunggu sampai spawner selesai memunculkan semua musuh
        while (spawnerScript.GetCurrentSpawnCount() < spawnerScript.totalSpawnLimit)
        {
            yield return null;
        }

        // Setelah selesai, matikan spawner saat ini
        spawners[index].SetActive(false);

        // Aktifkan spawner berikutnya
        currentSpawnerIndex++;
        if (currentSpawnerIndex < spawners.Count)
        {
            ActivateSpawner(currentSpawnerIndex);
        }
    }
}
