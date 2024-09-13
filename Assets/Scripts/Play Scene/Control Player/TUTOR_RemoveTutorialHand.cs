using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUTOR_RemoveTutorialHand : MonoBehaviour
{
    public GameObject LeftHand;
    public GameObject RightHand;

    public UnityEngine.Events.UnityEvent Grabbed;

    private void OnTriggerEnter(Collider other)
    {
        // Memeriksa apakah objek yang masuk adalah LeftHand atau RightHand
        if (other.gameObject == LeftHand || other.gameObject == RightHand)
        {
            Debug.Log("Hand entered the collider.");
            Grabbed.Invoke(); // Memanggil event Grabbed saat LeftHand atau RightHand masuk
        }
    }
}
