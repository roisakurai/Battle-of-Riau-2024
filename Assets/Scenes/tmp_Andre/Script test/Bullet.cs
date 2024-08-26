using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float bulletSpeed = 10.0f;
    public float attackRadius = 5.0f;
    public float attackDelay = 1.0f;
    public ParticleSystem attackEffect;
    public AudioClip attackSound;

    private float lastAttackTime;

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRadius);

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("NPC") && Time.time - lastAttackTime > attackDelay)
            {
                Transform target = FindNearestTargetWithTag("NPC");
                if (target != null)
                {
                    SpawnBulletAtTarget(target);
                    lastAttackTime = Time.time;
                }
            }
        }
    }

    void SpawnBulletAtTarget(Transform target)
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        Vector3 direction = (target.position - spawnPoint.position).normalized;
        bulletRigidbody.velocity = direction * bulletSpeed;

        if (attackEffect != null)
        {
            ParticleSystem effect = Instantiate(attackEffect, spawnPoint.position, Quaternion.identity);
            Destroy(effect.gameObject, effect.main.duration);
        }

        if (attackSound != null)
        {
            AudioSource.PlayClipAtPoint(attackSound, spawnPoint.position);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    Transform FindNearestTargetWithTag(string tag)
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);
        float nearestDistance = Mathf.Infinity;
        Transform nearestTarget = null;

        foreach (GameObject target in targets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestTarget = target.transform;
            }
        }

        return nearestTarget;
    }
}
