using UnityEngine;
using System.Collections;

public class PlayerPositionScene : MonoBehaviour
{
    public Transform[] targetPositions;
    public GameObject image;
    
    public BNG.SmoothLocomotion smoothLocomotion;

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < targetPositions.Length; i++)
        {
            if (other.gameObject.name == "Player Border " + (i + 1))
            {
                StartCoroutine(TeleportCoroutine(targetPositions[i].position));
                break;
            }
        }
    }

    IEnumerator TeleportCoroutine(Vector3 targetPosition)
    {
        smoothLocomotion.DisableMovement();

        image.SetActive(true);
        image.GetComponent<Animator>().enabled = true;

        transform.position = targetPosition;

        yield return new WaitForSeconds(0.5f);
        image.SetActive(false);
        
        smoothLocomotion.EnableMovement();
    }
}
