using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivedCanvas : MonoBehaviour
{
    public Canvas canvas;
    public float canvasDeactivateDelay = 15f;
    public GameObject teleportMap;
    public GameObject cannon;

    void Start()
    {
        StartCoroutine(DeactivateCanvasAfterDelay());
    }

    IEnumerator DeactivateCanvasAfterDelay()
    {
        yield return new WaitForSeconds(canvasDeactivateDelay);
        if (canvas != null)
        {
            canvas.gameObject.SetActive(false);
            teleportMap.SetActive(true);
            cannon.SetActive(true);
        }
    }
}
