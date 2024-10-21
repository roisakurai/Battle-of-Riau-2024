// using UnityEngine;
// using UnityEngine.UI;

// public class Healthbar : MonoBehaviour
// {
//     public Image healthbarSprite;
//     private Camera cam;

//     void Start()
//     {
//         cam = Camera.main;
//     }

//     void Update()
//     {
//         transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
//     }

//     public void UpdateHealthbar( float maxHealth, float currentHealth)
//     {
//         healthbarSprite.fillAmount = currentHealth / maxHealth;
//     }
// }

using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image healthbarSprite;
    private Camera cam;

    // Durasi animasi perubahan health bar
    private float animationSpeed = 3f;

    // Nilai target fill amount (akan digunakan untuk animasi)
    private float targetFillAmount;

    void Start()
    {
        cam = Camera.main;
        targetFillAmount = healthbarSprite.fillAmount;
    }

    void Update()
    {
        // Agar health bar selalu menghadap kamera
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);

        // Animasikan perubahan health bar
        healthbarSprite.fillAmount = Mathf.Lerp(healthbarSprite.fillAmount, targetFillAmount, Time.deltaTime * animationSpeed);
    }

    public void UpdateHealthbar(float maxHealth, float currentHealth)
    {
        // Hitung target fill amount baru berdasarkan health saat ini
        targetFillAmount = currentHealth / maxHealth;
    }
}
