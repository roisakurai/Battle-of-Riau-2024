using UnityEngine;

public class HandUIController : MonoBehaviour
{
    public Canvas uiCanvas;
    public float activationAngleMin = 90f;
    public float activationAngleMax = 120f;
    public bool sceneLoadInProgress = false;

    void Update()
    {
        if (!sceneLoadInProgress)
        {
            Vector3 handRotation = transform.eulerAngles;
            float zRotation = handRotation.z;

            if (zRotation >= activationAngleMin && zRotation <= activationAngleMax)
            {
                uiCanvas.gameObject.SetActive(true);
            }
            else
            {
                uiCanvas.gameObject.SetActive(false);
            }
        }
    }
}
