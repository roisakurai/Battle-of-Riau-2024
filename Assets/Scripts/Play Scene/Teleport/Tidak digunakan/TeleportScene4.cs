using UnityEngine;
using System.Collections;

public class TeleportScene4 : MonoBehaviour
{
    public Transform targetPosition1;
    public Transform targetPosition2;
    public Transform targetPosition3;
    public Transform targetPosition4;
    public Transform targetPosition5;
    public GameObject btnTeleport1;
    public GameObject btnTeleport2;
    public GameObject btnTeleport3;
    public GameObject btnTeleport4;
    public GameObject btnTeleport5;
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

    public void TeleportToTarget3()
    {
        StartCoroutine(TeleportCoroutine(targetPosition3.position));
    }

    public void TeleportToTarget4()
    {
        StartCoroutine(TeleportCoroutine(targetPosition4.position));
    }

    public void TeleportToTarget5()
    {
        StartCoroutine(TeleportCoroutine(targetPosition5.position));
    }

    IEnumerator TeleportCoroutine(Vector3 targetPosition)
    {
        smoothLocomotion.DisableMovement();

        image.SetActive(true);

        transform.position = targetPosition;
        transform.Rotate(0, 180, 0);

        btnTeleport1.SetActive(targetPosition != targetPosition1.position);
        btnTeleport2.SetActive(targetPosition != targetPosition2.position);
        btnTeleport3.SetActive(targetPosition != targetPosition3.position);
        btnTeleport4.SetActive(targetPosition != targetPosition4.position);
        btnTeleport5.SetActive(targetPosition != targetPosition5.position);

        audioSource.PlayOneShot(soundTeleport);

        image.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        image.SetActive(false);
        
        smoothLocomotion.EnableMovement();
    }
}
