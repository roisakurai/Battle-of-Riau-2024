using UnityEngine;

public class ArrowControllerLeft : MonoBehaviour
{
    public GameObject arrowPrefab;

    private bool isGrabberInside = false;
    private bool hasSpawnedArrow = false;
    private const string PrimaryHandTriggerAxis = "Oculus_CrossPlatform_PrimaryHandTrigger";

    private void Update()
    {
        float triggerValue = Input.GetAxis(PrimaryHandTriggerAxis);

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
