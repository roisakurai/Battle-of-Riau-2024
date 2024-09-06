using UnityEngine;

public class TUTOR_UIDelayFollow : MonoBehaviour
{
    public float distance;
    public Transform cameraTransform; // Transform dari kamera
    public float followSpeed = 0.1f; // Kecepatan mengikuti dengan delay
    private Vector3 currentVelocity;

    void LateUpdate()
    {
        // Menghitung posisi target UI berdasarkan posisi kamera
        Vector3 targetPosition = cameraTransform.position + cameraTransform.forward * distance;

        // Memindahkan UI ke posisi target dengan sedikit delay
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, followSpeed);

        // Mengatur rotasi UI untuk tetap menghadap ke arah kamera
        transform.rotation = Quaternion.LookRotation(transform.position - cameraTransform.position);
    }
}
