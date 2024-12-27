using UnityEngine;
using System.Collections;

public class TeleportPanah : MonoBehaviour
{
    public Transform[] targetPositions;
    public GameObject[] btnTeleports;
    public GameObject image;

    private AudioSource audioSource;
    public AudioClip soundTeleport;

    public BNG.SmoothLocomotion smoothLocomotion;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void TeleportToTarget(int targetIndex)
    {
        if (targetIndex >= 0 && targetIndex < targetPositions.Length)
        {
            StartCoroutine(TeleportCoroutine(targetIndex));
        }
    }

    IEnumerator TeleportCoroutine(int targetIndex)
    {
        smoothLocomotion.DisableMovement();

        image.SetActive(true);

        transform.position = targetPositions[targetIndex].position;
        transform.Rotate(0, 180, 0);

        // Update button visibility
        for (int i = 0; i < btnTeleports.Length; i++)
        {
            btnTeleports[i].SetActive(i != targetIndex);
        }

        audioSource.PlayOneShot(soundTeleport);

        image.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        image.SetActive(false);

        smoothLocomotion.EnableMovement();
    }
}
