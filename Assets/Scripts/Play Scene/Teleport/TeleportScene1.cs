using UnityEngine;
using System.Collections;

public class TeleportScene1 : MonoBehaviour
{
    public Transform targetPosition1;
    public Transform targetPosition2;
    public GameObject cannon1;
    public GameObject cannon2;
    public GameObject btnTeleport1;
    public GameObject btnTeleport2;
    public GameObject image;

    private AudioSource audioSource;
    public AudioClip soundTeleport;

    public BNG.SmoothLocomotion smoothLocomotion;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void TeleportToTarget1()
    {
        StartCoroutine(TeleportCoroutine(targetPosition1.position));
    }

    public void TeleportToTarget2()
    {
        StartCoroutine(TeleportCoroutine(targetPosition2.position));
    }

    IEnumerator TeleportCoroutine(Vector3 targetPosition)
    {
        smoothLocomotion.DisableMovement();

        image.SetActive(true);

        transform.position = targetPosition;
        transform.Rotate(0, 180, 0);

        cannon1.SetActive(!cannon1.activeSelf);
        cannon2.SetActive(!cannon2.activeSelf);
        btnTeleport1.SetActive(!btnTeleport1.activeSelf);
        btnTeleport2.SetActive(!btnTeleport2.activeSelf);

        audioSource.PlayOneShot(soundTeleport);

        image.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        image.SetActive(false);

        smoothLocomotion.EnableMovement();
    }
}
