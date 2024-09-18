using UnityEngine;
using System.Collections;

public class SLDR_FallShip : MonoBehaviour
{
    // Array untuk objek Fire, SoldierFall, dan SoldierShip
    public GameObject[] Fires;              // Array untuk objek Fire
    public GameObject[] SoldierFalls;       // Array untuk objek SoldierFall
    public GameObject[] SoldierShips;       // Array untuk objek SoldierShip

    public float soldierFallActiveTime = 3f; // Waktu aktif SoldierFall sebelum dihancurkan

    private bool[] hasSoldierFallen;         // Array untuk melacak soldier yang sudah jatuh

    private void Start()
    {
        hasSoldierFallen = new bool[SoldierShips.Length];
    }

private void Update()
{
    for (int i = 0; i < Fires.Length; i++)
    {
        // Mengecek apakah Game Object Fire aktif
        if (Fires[i].activeInHierarchy)
        {
            // Hidupkan SoldierFall dan hancurkan SoldierShip
            SoldierFalls[i].SetActive(true);

            if (!hasSoldierFallen[i])
            {
                // Pastikan SoldierShip masih ada sebelum menghancurkannya
                if (SoldierShips[i] != null)
                {
                    SoldierShips[i].SetActive(false);  // Nonaktifkan SoldierShip daripada menghancurkannya
                    hasSoldierFallen[i] = true;
                    StartCoroutine(DestroyAfterActiveTime(SoldierFalls[i], soldierFallActiveTime));
                }
            }
        }
        else
        {
            // Matikan SoldierFall dan hidupkan kembali SoldierShip
            SoldierFalls[i].SetActive(false);

            if (hasSoldierFallen[i])
            {
                // Pastikan SoldierShip belum dihancurkan sebelum menghidupkannya kembali
                if (SoldierShips[i] != null)
                {
                    SoldierShips[i].SetActive(true);
                    hasSoldierFallen[i] = false;
                }
            }
        }
    }
}


    private IEnumerator DestroyAfterActiveTime(GameObject soldierFall, float activeTime)
    {
        yield return new WaitForSeconds(activeTime);
        if (soldierFall.activeInHierarchy)
        {
            Destroy(soldierFall);
        }
    }
}
