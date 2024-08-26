using UnityEngine;

public class ShipNPC : MonoBehaviour
{
    [Header("Shooting Settings")]
    public float shootInterval = 2.0f;
    public float shootingRange = 10.0f;
    public float cannonballSpeed = 10.0f;
    public Transform[] spawnPoints;

    [Header("Attack Settings")]
    public float attackRadius = 10.0f;

    private float shootTimer = 0.0f;
    private PoolManager poolManager;

    void Start()
    {
        poolManager = FindObjectOfType<PoolManager>(); // Sesuaikan cara Anda menemukan PoolManager
    }

    void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRadius);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("NPC"))
                {
                    Shoot();
                    break;
                }
            }
            shootTimer = 0.0f;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    void Shoot()
    {
        if (spawnPoints != null && spawnPoints.Length > 0)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject cannonball = poolManager.GetPooledCannonball();

            if (cannonball != null)
            {
                cannonball.transform.position = spawnPoint.position;
                cannonball.transform.rotation = spawnPoint.rotation;
                cannonball.SetActive(true);

                Rigidbody rb = cannonball.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = spawnPoint.forward * cannonballSpeed;
                }
                else
                {
                    Debug.LogWarning("Rigidbody tidak ditemukan pada prefab cannonball.");
                }

                // Tambahkan kode untuk efek cannonball jika diperlukan
            }
            else
            {
                Debug.LogWarning("Tidak ada objek cannonball yang tersedia dalam pool.");
            }
        }
        else
        {
            Debug.LogWarning("Tidak ada titik spawn yang tersedia pada skrip EnemyNPC.");
        }
    }
}
