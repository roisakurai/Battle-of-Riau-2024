using UnityEngine;

public class ENMY_BoomDamage : MonoBehaviour
{
    public int BoomDamage;

    private void Start()
    {
        // Kosong atau dapat diisi sesuai kebutuhan
    }

    private void OnTriggerEnter(Collider other)
    {
        // Periksa apakah collider bertabrakan dengan tag "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Coba dapatkan komponen SoldierController
            SoldierController soldierHP = other.GetComponent<SoldierController>();
            if (soldierHP != null)
            {
                soldierHP.TakeDamage(BoomDamage);
                Die();
                return; // Keluar agar tidak melanjutkan logika berikut
            }

            // Coba dapatkan komponen ShipController jika SoldierController tidak ditemukan
            ShipController shipHP = other.GetComponent<ShipController>();
            if (shipHP != null)
            {
                shipHP.TakeDamage(BoomDamage);
                Die();
            }
        }
    }

    void Die()
    {
        // Hancurkan objek dengan jeda 1 detik
        Invoke(nameof(DestroyBoom), 1f);
    }

    void DestroyBoom()
    {
        Destroy(gameObject);
    }
}
