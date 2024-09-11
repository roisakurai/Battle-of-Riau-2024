using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierFalling : MonoBehaviour
{
    public ParticleSystem waterEffects; // Referensi ke particle system untuk efek air
    public AudioClip soundWater; // Referensi ke sound clip untuk suara air
    private AudioSource audioSource;
    private bool waterPlayed = false; // Cek apakah efek air sudah dimainkan

    void Start()
    {
        // Menambahkan komponen AudioSource untuk memainkan suara
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water") && !waterPlayed)
        {
            // Mainkan efek dan suara ketika prajurit menyentuh air
            PlayEffectsAndSound(soundWater, waterEffects);

            // Tandai bahwa efek sudah dimainkan
            waterPlayed = true;

            // Mulai coroutine untuk menghancurkan game object setelah 1 detik
            StartCoroutine(DestroyAfterDelay(1f));
        }
    }

    // Method untuk memainkan efek dan suara
    private void PlayEffectsAndSound(AudioClip sound, ParticleSystem effects)
    {
        audioSource.PlayOneShot(sound); // Mainkan suara air
        effects.transform.position = transform.position; // Pindahkan partikel ke posisi prajurit
        effects.Play(); // Mainkan efek partikel air
    }

    // Coroutine untuk menghancurkan game object setelah delay
    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
