using UnityEngine;

public class ButtonActivator : MonoBehaviour
{
    public GameObject nextButton;
    public int fallDownCountThreshold = 6;
    public GameObject Cannon_NPC;
    private int fallDownCount = 0;

    private void Start()
    {
        nextButton.SetActive(false);
    }

    private void Update()
    {
        if (fallDownCount >= fallDownCountThreshold)
        {
            nextButton.SetActive(true);
            Destroy(Cannon_NPC);
        }
    }

    public void IncrementFallDownCount()
    {
        fallDownCount++;
    }
}
