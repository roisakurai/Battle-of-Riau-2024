using UnityEngine;

public class SoldierTutorialController : MonoBehaviour
{
    public int maxHealth = 100;
    public Healthbar healthbar;

    private float currentHealth;
    private Animator animator;

    public int addPoints = 10;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.UpdateHealthbar(maxHealth, currentHealth);
        animator = GetComponent<Animator>();
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
        ScoreManager.instance.AddScore(addPoints);
        animator.SetTrigger("isDead");
        GetComponent<AudioSource>().Play();

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
