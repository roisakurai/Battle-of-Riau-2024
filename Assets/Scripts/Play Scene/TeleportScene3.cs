using UnityEngine;
using System.Collections;

public class TeleportScene3 : MonoBehaviour
{
    public Transform targetPosition1;
    public Transform targetPosition2;
    public Transform targetPosition3;
    public GameObject cannon1;
    public GameObject cannon2;
    public GameObject cannon3;
    public GameObject btnTeleport1;
    public GameObject btnTeleport2;
    public GameObject btnTeleport3;
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

    IEnumerator TeleportCoroutine(Vector3 targetPosition)
    {
        smoothLocomotion.DisableMovement();

        image.SetActive(true);

        transform.position = targetPosition;

        cannon1.SetActive(false);
        cannon2.SetActive(false);
        cannon3.SetActive(false);
        btnTeleport1.SetActive(false);
        btnTeleport2.SetActive(false);
        btnTeleport3.SetActive(false);

        if (targetPosition == targetPosition1.position)
        {
            cannon1.SetActive(true);
            btnTeleport2.SetActive(true);
            btnTeleport3.SetActive(true);
        }
        else if (targetPosition == targetPosition2.position)
        {
            cannon2.SetActive(true);
            btnTeleport1.SetActive(true);
            btnTeleport3.SetActive(true);
        }
        else if (targetPosition == targetPosition3.position)
        {
            cannon3.SetActive(true);
            btnTeleport1.SetActive(true);
            btnTeleport2.SetActive(true);
        }

        audioSource.PlayOneShot(soundTeleport);

        image.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        image.SetActive(false);

        smoothLocomotion.EnableMovement();
    }

}
