using UnityEngine;

public class ENMY_Boom : MonoBehaviour
{
    public GameObject Barrel, Explosion;

    private AudioSource source;

    [SerializeField]
    private float range;

    private void Awake()
    {
        Barrel.SetActive(true);
        Explosion.SetActive(false);

        source = GetComponent<AudioSource>();
    }

    public void Explode()
    {
        Barrel.SetActive(false);
        Explosion.SetActive(true);

        source.Play();
        this.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
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
        Invoke(nameof(DestroyBoom),2f);
    }

    void DestroyBoom()
    {
        Destroy(gameObject);
    }
}
