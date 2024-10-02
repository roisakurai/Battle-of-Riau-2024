using UnityEngine;
using System.Collections;

public class Cannon_NPC : MonoBehaviour
{
    public GameObject cannonballPrefab;
    public Transform shotPoint;
    public ParticleSystem smokeEffect;
    private float lastFireTime = 0f;
    public float fireCooldown = 5f; // Set ke 5 detik
    public float delayStart;
    private AudioSource audioSource;
    private float cannonballForce => VariableManager.instance.cannonballForce;
    private float cannonballLifetime => VariableManager.instance.cannonballLifetime;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(AutoFire());
    }

    IEnumerator AutoFire()
    {
        yield return new WaitForSeconds(delayStart);

        while (true)
        {
            if (Time.time - lastFireTime >= fireCooldown)
            {
                ShootCannonball();
                lastFireTime = Time.time;
            }
            yield return null;
        }
    }

    public void ShootCannonball()
    {
        GameObject cannonballInstance = Instantiate(cannonballPrefab, shotPoint.position, Quaternion.identity);

        if (cannonballInstance != null)
        {
            Rigidbody cannonballRigidbody = cannonballInstance.GetComponent<Rigidbody>();
            if (cannonballRigidbody != null)
            {
                Vector3 fireDirection = transform.forward;
                cannonballRigidbody.velocity = fireDirection * cannonballForce;
            }

            StartCoroutine(ReturnCannonballToPool(cannonballInstance));
        }

        audioSource.Play();
        smokeEffect.Play();
    }

    private IEnumerator ReturnCannonballToPool(GameObject cannonballInstance)
    {
        yield return new WaitForSeconds(cannonballLifetime);
        Destroy(cannonballInstance);
    }
}
