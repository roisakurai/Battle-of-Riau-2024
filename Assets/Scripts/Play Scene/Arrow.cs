using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int arrowDamage = 10;

    private const string GroundTag = "Ground";
    private const string EnemyTag = "Enemy";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GroundTag))
        {
            DisableArrow();
            return;
        }

        if (collision.gameObject.CompareTag(EnemyTag))
        {
            if (collision.gameObject.TryGetComponent<SoldierController>(out var enemyHP))
            {
                enemyHP.TakeDamage(arrowDamage);
            }
            DisableArrow();
        }
    }

    private void DisableArrow()
    {
        Destroy(GetComponent<Rigidbody>());
        Destroy(GetComponent<Collider>());

        Invoke(nameof(DestroyAfterDelay), 10f);
    }

    private void DestroyAfterDelay()
    {
        Destroy(gameObject);
    }
}
