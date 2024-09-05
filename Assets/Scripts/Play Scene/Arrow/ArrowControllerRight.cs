using UnityEngine;

public class ArrowControllerRight : MonoBehaviour
{
    public GameObject arrowPrefab;

    private bool isGrabberInside = false;
    private bool hasSpawnedArrow = false;
    private const string SecondaryHandTriggerAxis = "Oculus_CrossPlatform_SecondaryHandTrigger";

    private void Update()
    {
        float triggerValue = Input.GetAxis(SecondaryHandTriggerAxis);

        if (isGrabberInside && triggerValue > 0 && !hasSpawnedArrow)
        {
            SpawnArrow();
        }

        if (triggerValue <= 0)
        {
            hasSpawnedArrow = false;
        }
    }

    private void SpawnArrow()
    {
        GameObject spawnedArrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
        spawnedArrow.SetActive(true);
        hasSpawnedArrow = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ArrowSpawner"))
        {
            isGrabberInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ArrowSpawner"))
        {
            isGrabberInside = false;
        }
    }
}
