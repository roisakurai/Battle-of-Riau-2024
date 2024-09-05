using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUTOR_TampilanTeleport : MonoBehaviour
{
    public GameObject TampilanTeleport;

    private void OnCollisionEnter(Collision collision)
    {
        // Ganti "YourTag" dengan tag yang sesuai yang ingin diperiksa
        if(collision.gameObject.CompareTag("Player")) 
        {
            TampilanTeleport.SetActive(true);
        }
    }
}
