using UnityEngine;

public class Teleport2 : MonoBehaviour
{
    public Vector3 teleportLocation2;   // Lokasi teleportasi kedua

    public void Teleport()
    {
        Transform objectTransform = transform;
        objectTransform.position = teleportLocation2;
    }
}