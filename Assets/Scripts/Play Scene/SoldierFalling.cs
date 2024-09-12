using UnityEngine;

public class SoldierFalling : MonoBehaviour 
{
    public AudioClip soundWater;           // Clip suara air
    public ParticleSystem waterEffect;     // Efek partikel air
    private AudioSource audioSource;       // Audio source untuk memainkan suara

    private void Start() {
        // Menambahkan AudioSource ke objek dan menyimpannya ke dalam variabel
        audioSource = gameObject.AddComponent<AudioSource>();
    }   

    private void OnTriggerEnter(Collider other) {
        // Jika objek yang bersentuhan memiliki tag "Water"
        if(other.CompareTag("Water"))
        {
            Debug.Log("Bunyi");
            // Memainkan suara air menggunakan AudioSource
            audioSource.PlayOneShot(soundWater);
            // Memainkan efek partikel air
            waterEffect.Play();
        }
    }
}
