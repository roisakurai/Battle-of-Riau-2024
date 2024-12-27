using UnityEngine;
using System.Collections;

public class TeleportScene : MonoBehaviour
{
    public Transform[] targetPositions;  // Array untuk target teleportasi
    public GameObject[] cannons;         // Array untuk cannon
    public GameObject[] btnTeleports;    // Array untuk tombol teleport
    public GameObject image;

    private AudioSource audioSource;
    public AudioClip soundTeleport;

    public BNG.SmoothLocomotion smoothLocomotion;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Fungsi teleport yang menerima index target
    public void TeleportToTarget(int index)
    {
        if (index >= 0 && index < targetPositions.Length)  // Pastikan index valid
        {
            StartCoroutine(TeleportCoroutine(targetPositions[index].position, index));
        }
    }

    // Coroutine teleport ke posisi target tertentu
    IEnumerator TeleportCoroutine(Vector3 targetPosition, int index)
    {
        smoothLocomotion.DisableMovement();

        image.SetActive(true);

        transform.position = targetPosition;
        transform.Rotate(0, 180, 0);

        // Mengaktifkan atau menonaktifkan cannon dan tombol teleport berdasarkan index
        for (int i = 0; i < cannons.Length; i++)
        {
            cannons[i].SetActive(i == index);  // Aktifkan cannon yang sesuai dengan index
        }

        for (int i = 0; i < btnTeleports.Length; i++)
        {
            btnTeleports[i].SetActive(i == index);  // Aktifkan tombol teleport yang sesuai dengan index
        }

        audioSource.PlayOneShot(soundTeleport);

        image.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        image.SetActive(false);

        smoothLocomotion.EnableMovement();
    }
}
