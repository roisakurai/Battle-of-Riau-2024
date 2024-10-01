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
    if (other.CompareTag("Water"))
    {
        Debug.Log("Bunyi");
        
        // Cek apakah audioSource dan soundWater tidak null
        if (audioSource != null && soundWater != null)
        {
            audioSource.PlayOneShot(soundWater);
        }
        else
        {
            Debug.LogWarning("AudioSource atau soundWater belum diisi!");
        }
        
        // Cek apakah waterEffect tidak null
        if (waterEffect != null)
        {
            waterEffect.Play();
        }
        else
        {
            Debug.LogWarning("WaterEffect belum diisi!");
        }
    }
}

}
