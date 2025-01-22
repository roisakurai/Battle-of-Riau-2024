using UnityEngine;

public class ENMY_FollowShip : MonoBehaviour
{
    // Objek yang akan diikuti (drag & drop di Inspector)
    public Transform target;

    // Kecepatan mengikuti
    public float followSpeed = 5f;

    // Kecepatan rotasi
    public float rotationSpeed = 10f;

    // Jarak offset di belakang target
    public float followDistance = 2f;

    // Tinggi offset (opsional)
    public float heightOffset = 1f;

    void Update()
    {
        if (target != null)
        {
            // Hitung posisi di belakang target
            Vector3 targetPosition = target.position - target.forward * followDistance + Vector3.up * heightOffset;

            // Gerakan halus ke posisi target
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

            // Rotasi menghadap target
            Quaternion targetRotation = Quaternion.LookRotation(target.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
