// using UnityEngine;

// public class SoldierTutorialController : MonoBehaviour
// {
//     public int maxHealth = 100;
//     public Healthbar healthbar;

//     private float currentHealth;
//     private Animator animator;

//     public int addPoints = 10;

//     void Start()
//     {
//         currentHealth = maxHealth;
//         healthbar.UpdateHealthbar(maxHealth, currentHealth);
//         animator = GetComponent<Animator>();
//     }

//     public void TakeDamage(int damageAmount)
//     {
//         currentHealth -= damageAmount;
//         healthbar.UpdateHealthbar(maxHealth, currentHealth);

//         if (currentHealth <= 0)
//         {
//             Die();
//         }
//     }

//     void Die()
//     {
//         ScoreManager.instance.AddScore(addPoints);
//         animator.SetTrigger("isDead");
//         GetComponent<AudioSource>().Play();

//         Collider collider;
//         if (TryGetComponent(out collider))
//         {
//             Destroy(collider);
//         }

//         Rigidbody rigidbody;
//         if (TryGetComponent(out rigidbody))
//         {
//             Destroy(rigidbody);
//         }

//         Transform parentTransform = transform.parent;
//         transform.SetParent(null);

//         if (parentTransform != null)
//         {
//             Destroy(parentTransform.gameObject);
//         }

//         Invoke(nameof(DestroyEnemy), 0f);
//     }

//     void DestroyEnemy()
//     {
//         Destroy(gameObject);
//         ButtonActivator buttonActivator = FindObjectOfType<ButtonActivator>();
//         if (buttonActivator != null)
//         {
//             buttonActivator.IncrementFallDownCount();
//         }
//         CanvasActivator canvasActivator = FindObjectOfType<CanvasActivator>();
//         if (canvasActivator != null)
//         {
//             canvasActivator.IncrementFallDownCount();
//         }
//     }
// }
using UnityEngine;

public class SoldierTutorialController : MonoBehaviour
{
    public int maxHealth = 100;
    public Healthbar healthbar; // Pastikan sudah diassign di Inspector Unity

    private float currentHealth;
    private AudioSource audioSource; // Pastikan AudioSource ada di GameObject ini

    void Start()
    {
        currentHealth = maxHealth;

        // Pastikan healthbar sudah di-assign
        if (healthbar != null)
        {
            healthbar.UpdateHealthbar(maxHealth, currentHealth);
        }
        else
        {
            Debug.LogError("Healthbar is not assigned in the Inspector.");
        }

        // Ambil komponen AudioSource, jika tidak ada, log error
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on " + gameObject.name);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (healthbar != null)
        {
            healthbar.UpdateHealthbar(maxHealth, currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Pastikan audioSource tidak null sebelum menggunakan
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // Hapus komponen Collider dan Rigidbody jika ada
        Collider collider;
        if (TryGetComponent(out collider))
        {
            Destroy(collider);
        }

        Rigidbody rigidbody;
        if (TryGetComponent(out rigidbody))
        {
            Destroy(rigidbody);
        }

        // Pisahkan dari parent dan hapus parent jika ada
        Transform parentTransform = transform.parent;
        transform.SetParent(null);

        if (parentTransform != null)
        {
            Destroy(parentTransform.gameObject);
        }

        Invoke(nameof(DestroyEnemy), 0f);
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);

        // Update ButtonActivator dan CanvasActivator jika ada
        ButtonActivator buttonActivator = FindObjectOfType<ButtonActivator>();
        if (buttonActivator != null)
        {
            buttonActivator.IncrementFallDownCount();
        }

        CanvasActivator canvasActivator = FindObjectOfType<CanvasActivator>();
        if (canvasActivator != null)
        {
            canvasActivator.IncrementFallDownCount();
        }
    }
}
