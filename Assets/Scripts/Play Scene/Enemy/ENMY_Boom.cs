// using UnityEngine;

// public class ENMY_Boom : MonoBehaviour
// {
//     public GameObject Barrel, Explosion;

//     private AudioSource source;

//     [SerializeField]
//     private float range;

//     private void Awake()
//     {
//         Barrel.SetActive(true);
//         Explosion.SetActive(false);

//         source = GetComponent<AudioSource>();
//     }

//     public void Explode()
//     {
//         Barrel.SetActive(false);
//         Explosion.SetActive(true);

//         source.Play();
//         this.enabled = false;
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Arrow") || (other.CompareTag("Cannon Ball")))
//         {
//             Explode();
//             Destroy(other.gameObject);
//             Die();
//         }
//     }

//     private void OnDrawGizmos()
//     {
//         Gizmos.DrawWireSphere(transform.position, range);
//     }

//     void Die()
//     {
//         Invoke(nameof(DestroyBoom), 2f);
//     }

//     void DestroyBoom()
//     {
//         Destroy(gameObject);
//     }
// }
using UnityEngine;

public class ENMY_Boom : MonoBehaviour
{
    public GameObject Barrel;
    public GameObject[] Explosions; // Array untuk menampung banyak efek ledakan

    private AudioSource source;

    [SerializeField]
    private float range;

    private void Awake()
    {
        Barrel.SetActive(true);
        
        // Pastikan semua ledakan dinonaktifkan saat memulai
        foreach (var explosion in Explosions)
        {
            explosion.SetActive(false);
        }

        source = GetComponent<AudioSource>();
    }

    public void Explode()
    {
        Barrel.SetActive(false);

        // Aktifkan semua efek ledakan di dalam array
        foreach (var explosion in Explosions)
        {
            explosion.SetActive(true);
        }

        // Mainkan efek suara
        if (source != null)
        {
            source.Play();
        }

        this.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow") || (other.CompareTag("Cannon Ball")))
        {
            Explode();
            Destroy(other.gameObject);
            Die();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Die()
    {
        Invoke(nameof(DestroyBoom), 2f);
    }

    void DestroyBoom()
    {
        Destroy(gameObject);
    }
}
