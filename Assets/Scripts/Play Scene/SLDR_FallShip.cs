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
                // Hidupkan SoldierFall
                if (SoldierFalls[i] != null)
                {
                    SoldierFalls[i].SetActive(true);
                }

                if (!hasSoldierFallen[i] && SoldierShips[i] != null)
                {
                    // Nonaktifkan SoldierShip tanpa menghancurkannya
                    SoldierShips[i].SetActive(false);  
                    hasSoldierFallen[i] = true;
                    
                    // Mulai penghancuran SoldierFall setelah waktu aktif habis
                    StartCoroutine(DestroyAfterActiveTime(SoldierFalls[i], soldierFallActiveTime));
                }
            }
            else
            {
                // Matikan SoldierFall dan hidupkan kembali SoldierShip
                if (SoldierFalls[i] != null)
                {
                    SoldierFalls[i].SetActive(false);
                }

                if (hasSoldierFallen[i] && SoldierShips[i] != null)
                {
                    SoldierShips[i].SetActive(true);
                    hasSoldierFallen[i] = false;
                }
            }
        }
    }

    private IEnumerator DestroyAfterActiveTime(GameObject soldierFall, float activeTime)
    {
        yield return new WaitForSeconds(activeTime);
        
        // Periksa lagi apakah objek masih ada sebelum menghancurkannya
        if (soldierFall != null && soldierFall.activeInHierarchy)
        {
            Destroy(soldierFall);
        }
    }
}
