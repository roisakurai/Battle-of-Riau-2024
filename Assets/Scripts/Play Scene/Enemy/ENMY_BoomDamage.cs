using UnityEngine;

public class ENMY_BoomDamage : MonoBehaviour
{
    public int BoomDamage;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            SoldierController enemyHP = other.GetComponent<SoldierController>();
            if (enemyHP != null)
            {
                enemyHP.TakeDamage(BoomDamage);
            }
            Die();
        }
    }

    void Die()
    {
        Invoke(nameof(DestroyBoom),1f);
    }

    void DestroyBoom()
    {
        Destroy(gameObject);
    }
}
