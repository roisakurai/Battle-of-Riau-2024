using UnityEngine;

public class SoldierController : MonoBehaviour
{
    public int maxHealth;
    public Healthbar healthbar;
    private float currentHealth;
    private Animator animator;
    private ScoreManager scoreManager;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.UpdateHealthbar(maxHealth, currentHealth);
        animator = GetComponent<Animator>();

        // Pastikan ScoreManager ditemukan
        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager tidak ditemukan di scene.");
        }
    }

    void DestroyEnemy()
    {
        // Tambahkan skor jika ScoreManager tersedia
        if (scoreManager != null)
        {
            scoreManager.AddScore(10);
        }

        // Hancurkan objek musuh
        Destroy(gameObject);

        // Cek keberadaan ButtonActivator dan CanvasActivator
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

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthbar.UpdateHealthbar(maxHealth, currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Trigger animasi mati jika animator tersedia
        if (animator != null)
        {
            animator.SetTrigger("isDead");
        }

        // Hentikan pergerakan Rigidbody dan nonaktifkan pengaruh physics
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.isKinematic = true; // Menghentikan pengaruh fisika
        }

        // Hapus BoxCollider untuk menghindari tabrakan lebih lanjut
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        if (boxCollider != null)
        {
            Destroy(boxCollider);
        }

        // Pisahkan objek dari parent, jika ada, dan hancurkan parent jika diperlukan
        Transform parentTransform = transform.parent;
        transform.SetParent(null);

        if (parentTransform != null)
        {
            Destroy(parentTransform.gameObject);
        }

        // Mainkan suara mati jika AudioSource tersedia
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // Hancurkan objek setelah animasi selesai (3 detik)
        Invoke(nameof(DestroyEnemy), 3f);
    }
}
