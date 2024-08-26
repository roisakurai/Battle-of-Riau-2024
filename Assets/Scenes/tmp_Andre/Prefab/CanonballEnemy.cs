using UnityEngine;

public class CanonballEnemy : MonoBehaviour
{
    public ParticleSystem smokeEffects;

    private int canonballDamage => VariableManager.instance.cannonballDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")/* && other is MeshCollider*/)
        {
            ShipController enemyHP = other.GetComponent<ShipController>();
            if (enemyHP != null)
            {
                enemyHP.TakeDamage(canonballDamage);
            }
            GetComponent<AudioSource>().Play();
            smokeEffects.Play();
        }
    }
}