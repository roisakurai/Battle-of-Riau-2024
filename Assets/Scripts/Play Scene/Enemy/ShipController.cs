using UnityEngine;
using UnityEngine.Events;

public class ShipController : MonoBehaviour
{
    public int maxHealth = 100;
    public Healthbar healthbar;
    public GameObject particleExplosion;
    public GameObject[] fireObjects;

    private float currentHealth;
    private bool isDead = false;
    private int currentFireIndex = 0;

    private float fallDownSpeed => VariableManager.instance.fallDownSpeed;

    // Reference to ScoreManager
    public ScoreManager scoreManager;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.UpdateHealthbar(maxHealth, currentHealth);

        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager tidak ditemukan di scene.");
        }
    }

    void Update()
    {
        if (isDead)
        {
            Invoke(nameof(FallDown), 1f);
            return;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthbar.UpdateHealthbar(maxHealth, currentHealth);

        if (currentHealth % 10 == 0)
        {
            ActivateNextFireObject();
        }

        if (currentHealth <= 0 && !isDead)
        {
            if (scoreManager != null)
            {
                scoreManager.AddScore(10); // Add a fixed score (10 points)
            }
            Die();
        }
    }

    void ActivateNextFireObject()
    {
        if (currentFireIndex < fireObjects.Length)
        {
            fireObjects[currentFireIndex].SetActive(true);
            currentFireIndex++;
        }
    }

    void Die()
    {
        isDead = true;
        // Update score when ship dies (fixed points of 10)
        Destroy(GetComponent<Rigidbody>());
        Destroy(GetComponent<BoxCollider>());

        Transform parentTransform = transform.parent?.parent;
        transform.SetParent(null);

        if (parentTransform != null)
        {
            Destroy(parentTransform.gameObject);
        }
    }

    void FallDown()
    {
        transform.Translate(fallDownSpeed * Time.deltaTime * Vector3.down);
        particleExplosion.SetActive(true);

        if (transform.position.y < -30f)
        {
            Destroy(gameObject);
            ButtonActivator buttonActivator = FindObjectOfType<ButtonActivator>();
            buttonActivator?.IncrementFallDownCount();
        }
    }
}