using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int arrowDamage = 10;
    public AudioClip groundHitSound;  // Tambahkan AudioClip untuk suara ketika mengenai tanah
    public AudioClip enemyHitSound;   // Tambahkan AudioClip untuk suara ketika mengenai musuh
    private AudioSource audioSource;  // Komponen AudioSource untuk memutar suara

    private const string GroundTag = "Ground";
    private const string EnemyTag = "Enemy";

    private void Start()
    {
        // Inisialisasi AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GroundTag))
        {
            PlaySound(groundHitSound);  // Mainkan suara ketika mengenai tanah
            DisableArrow();
            return;
        }

        if (collision.gameObject.CompareTag(EnemyTag))
        {
            if (collision.gameObject.TryGetComponent<SoldierController>(out var enemyHP))
            {
                enemyHP.TakeDamage(arrowDamage);
                PlaySound(enemyHitSound);  // Mainkan suara ketika mengenai musuh
            }
            else if (collision.gameObject.TryGetComponent<SoldierTutorialController>(out var enemyHP2))
            {
                enemyHP2.TakeDamage(arrowDamage);
                PlaySound(enemyHitSound);  // Mainkan suara ketika mengenai musuh
            }
            DisableArrow();
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    // private void DisableArrow()
    // {
    //     Destroy(GetComponent<Rigidbody>());
    //     Destroy(GetComponent<Collider>());

    //     Invoke(nameof(DestroyAfterDelay), 10f);
    // }
    private void DisableArrow()
    {
        // Cek apakah objek memiliki komponen FixedJoint
        FixedJoint joint = GetComponent<FixedJoint>();
        if (joint != null)
        {
            Destroy(joint); // Hapus FixedJoint terlebih dahulu
        }

        Destroy(GetComponent<Rigidbody>()); // Hapus Rigidbody setelah FixedJoint
        Destroy(GetComponent<Collider>());  // Hapus Collider

        Invoke(nameof(DestroyAfterDelay), 10f);
    }


    private void DestroyAfterDelay()
    {
        Destroy(gameObject);
    }
}
