using UnityEngine;

public class ArrowMusic : MonoBehaviour
{
    private AudioSource audioSource; // Komponen untuk memainkan suara
    public AudioClip soundSoldier, soundLand; // Klip suara untuk tentara dan daratan
    private bool soldierPlayed = false; // Penanda jika suara tentara telah dimainkan
    private bool landPlayed = false; // Penanda jika suara darat telah dimainkan

    void Start()
    {
        // Tambahkan komponen AudioSource ke game object ini
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 1.0f; // Volume penuh
        audioSource.mute = false; // Tidak bisu

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!soldierPlayed && !landPlayed)
        {
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("Enemy Terdeteksi"); // Pesan Debug
                PlaySound(soundSoldier, ref soldierPlayed);
            }

            if (other.CompareTag("Ground"))
            {
                Debug.Log("Ground Terdeteksi"); // Pesan Debug
                PlaySound(soundLand, ref landPlayed);
            }
        }
    }


    // Fungsi untuk memainkan suara
    private void PlaySound(AudioClip sound, ref bool playedFlag)
    {
        // Pastikan klip suara ada dan audio belum dimainkan
        if (sound != null && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(sound); // Mainkan klip suara sekali
            playedFlag = true; // Tandai bahwa suara telah dimainkan
        }
    }
}
