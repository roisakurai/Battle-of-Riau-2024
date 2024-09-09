using UnityEngine;

public class TUTOR_TampilanNextScene : MonoBehaviour
{
    // Objek yang akan dihancurkan
    public GameObject[] objectsToDestroy;

    // Objek yang akan muncul setelah ketiga objek dihancurkan
    public GameObject objectToSpawn;

    // Jumlah objek yang telah dihancurkan
    private int destroyedCount = 0;

    void Start()
    {
        // Memastikan objek yang akan muncul tidak aktif saat mulai
        objectToSpawn.SetActive(false);
    }

    public void ObjectDestroyed()
    {
        // Menambahkan jumlah objek yang dihancurkan
        destroyedCount++;

        // Cek jika tiga objek sudah dihancurkan
        if (destroyedCount >= 3)
        {
            // Mengaktifkan objek yang akan muncul
            objectToSpawn.SetActive(true);
        }
    }
}
