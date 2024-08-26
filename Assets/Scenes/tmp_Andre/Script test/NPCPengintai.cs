using UnityEngine;

public class NPCPengintai : MonoBehaviour
{
    public GameObject objekMusuh; // Objek yang akan dideteksi
    public float radiusDeteksi; // Jarak deteksi
    public AudioClip audioKetikaTerdeteksi; // Audio yang akan dimainkan

    private AudioSource audioSource;
    private bool audioSedangDimainkan = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float jarak = Vector3.Distance(transform.position, objekMusuh.transform.position);

        if (jarak <= radiusDeteksi && !audioSedangDimainkan)
        {
            // Mainkan audio jika belum dimainkan
            audioSource.clip = audioKetikaTerdeteksi;
            audioSource.Play();
            audioSedangDimainkan = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Tampilkan area deteksi pada editor Unity
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radiusDeteksi);
    }
}
