using UnityEngine;

public class CanvasActivator : MonoBehaviour
{
    public GameObject endText;
    public int fallDownCountThreshold = 6;

    private int fallDownCount = 0;

    private void Start()
    {
        endText.SetActive(false);
    }

    private void Update()
    {
        if (fallDownCount >= fallDownCountThreshold)
        {
            endText.SetActive(true);
        }
    }

    public void IncrementFallDownCount()
    {
        fallDownCount++;
    }
}
