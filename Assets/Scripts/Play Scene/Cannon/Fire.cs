using UnityEngine;

public class Fire : MonoBehaviour
{
    public CannonController cannonController;
    public GameObject fuse, spark;

    public float fuseDelay = 1f;
    public float fuseCooldown = 2f;

    private Collider fuseCollider;

    private void Start()
    {
        fuseCollider = fuse.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Fuse")
        {
            fuseCollider.enabled = false;
            spark.SetActive(true);
            GetComponent<AudioSource>().Play();
            Invoke(nameof(IgniteFuse), fuseDelay);
        }
    }

    public void MoveDown()
    {
        transform.Translate(Vector3.down * 0.1f);
    }


    private void IgniteFuse()
    {
        cannonController.ShootCannonball();
        fuse.SetActive(false);
        spark.SetActive(false);
        Invoke(nameof(ActivateFuse), fuseCooldown);
    }

    private void ActivateFuse()
    {
        fuse.SetActive(true);
        fuseCollider.enabled = true;
    }
}
