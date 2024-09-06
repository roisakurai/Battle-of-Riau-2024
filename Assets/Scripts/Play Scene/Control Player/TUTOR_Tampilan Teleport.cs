using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUTOR_TampilanTeleport : MonoBehaviour
{
    public GameObject TampilanTeleport;

    private void OnTriggerEnter(Collider other)
    {
        // Ganti "YourTag" dengan tag yang sesuai yang ingin diperiksa
        if(other.CompareTag("Player")) 
        {
            TampilanTeleport.SetActive(true);
        }
    }
}
