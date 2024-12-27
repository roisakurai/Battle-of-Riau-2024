using UnityEngine;
using System.Collections;

public class TeleportCanon : MonoBehaviour
{
    public Transform[] targetPositions;
    public GameObject[] cannons;
    public GameObject[] teleportButtons;
    public GameObject image;

    public AudioClip soundTeleport;

    private AudioSource audioSource;
    private BNG.SmoothLocomotion smoothLocomotion;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        smoothLocomotion = GetComponent<BNG.SmoothLocomotion>();
    }

    public void TeleportToTarget(int targetIndex)
    {
        StartCoroutine(TeleportCoroutine(targetPositions[targetIndex].position, targetIndex));
    }

    IEnumerator TeleportCoroutine(Vector3 targetPosition, int targetIndex)
    {
        smoothLocomotion.DisableMovement();

        image.SetActive(true);

        transform.position = targetPosition;
        transform.Rotate(0, 180, 0);

        SetActiveObjects(targetIndex);

        audioSource.PlayOneShot(soundTeleport);

        Animator imageAnimator = image.GetComponent<Animator>();
        if (imageAnimator != null)
        {
            imageAnimator.enabled = true;
            yield return new WaitForSeconds(0.5f);
        }

        image.SetActive(false);

        smoothLocomotion.EnableMovement();
    }

    private void SetActiveObjects(int targetIndex)
    {
        foreach (GameObject cannon in cannons)
        {
            cannon.SetActive(false);
        }

        foreach (GameObject button in teleportButtons)
        {
            button.SetActive(false);
        }

        if (targetIndex >= 0 && targetIndex < cannons.Length)
        {
            cannons[targetIndex].SetActive(true);
        }

        for (int i = 0; i < teleportButtons.Length; i++)
        {
            if (i != targetIndex && i >= 0 && i < teleportButtons.Length)
            {
                teleportButtons[i].SetActive(true);
            }
        }
    }
}
