using UnityEngine;

public class ButtonActivator : MonoBehaviour
{
    public GameObject nextButton;
    public int fallDownCountThreshold = 6;
    public GameObject NPC_Team;
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
            Destroy(NPC_Team);
        }
    }

    public void IncrementFallDownCount()
    {
        fallDownCount++;
    }
}
