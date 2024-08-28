using UnityEngine;

public class LasserActive : MonoBehaviour
{
    // Referensi ke GameObject yang ingin diaktifkan/dinonaktifkan
    public GameObject Lasser;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player memasuki trigger");
            // Aktifkan GameObject Lasser saat Player memasuki trigger
            if (Lasser != null)
            {
                Lasser.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Lasser tidak di-assign di Inspector!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player meninggalkan trigger");
            // Nonaktifkan GameObject Lasser saat Player keluar dari trigger
            if (Lasser != null)
            {
                Lasser.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Lasser tidak di-assign di Inspector!");
            }
        }
    }
}
