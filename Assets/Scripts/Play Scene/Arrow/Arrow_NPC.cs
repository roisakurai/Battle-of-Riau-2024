using UnityEngine;
using System.Collections;

public class Arrow_NPC : MonoBehaviour
{
    public GameObject arrowPrefab; // Prefab anak panah
    public Transform shotPoint; // Titik tembak anak panah
    public float shootCooldown = 5f; // Cooldown untuk menembak setiap 5 detik
    public float delayStart = 0f; // Waktu delay sebelum mulai menembak
    public float arrowSpeed = 10f; // Kecepatan anak panah
    public float arrowLifetime = 5f; // Lama waktu hidup anak panah
    private AudioSource audioSource; // Komponen Audio untuk suara menembak

    void Start()
    {
        // Mendapatkan komponen AudioSource untuk suara
        audioSource = GetComponent<AudioSource>();
        // Memulai korutin untuk menembak secara terus menerus
        StartCoroutine(AutoShoot());
    }

    IEnumerator AutoShoot()
    {
        // Menunggu sesuai dengan delay awal
        yield return new WaitForSeconds(delayStart);

        while (true)
        {
            // Memanggil fungsi menembak panah
            ShootArrow();
            // Menunggu selama cooldown sebelum menembak lagi
            yield return new WaitForSeconds(shootCooldown);
        }
    }

    public void ShootArrow()
    {
        // Membuat instance anak panah di titik tembak
        GameObject arrowInstance = Instantiate(arrowPrefab, shotPoint.position, shotPoint.rotation);

        if (arrowInstance != null)
        {
            // Mengatur kecepatan anak panah
            Rigidbody arrowRigidbody = arrowInstance.GetComponent<Rigidbody>();
            if (arrowRigidbody != null)
            {
                Vector3 fireDirection = transform.forward; // Arah tembak ke depan NPC
                arrowRigidbody.velocity = fireDirection * arrowSpeed; // Set kecepatan panah
            }

            // Menghapus anak panah setelah waktu hidup habis
            StartCoroutine(ReturnArrowToPool(arrowInstance));
        }

        // Memainkan suara dan efek visual saat menembak
        audioSource.Play();
    }

    private IEnumerator ReturnArrowToPool(GameObject arrowInstance)
    {
        // Menunggu selama waktu hidup panah sebelum menghapusnya
        yield return new WaitForSeconds(arrowLifetime);
        Destroy(arrowInstance); // Menghapus anak panah setelah waktu hidup habis
    }
}
