using UnityEngine;

public class ButtonActivator : MonoBehaviour
{
    public GameObject nextButton;
    public int fallDownCountThreshold = 6;
    public GameObject[] NPC_TeamArray; // Array untuk menyimpan beberapa NPC
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
            DestroyAllNPCs(); // Panggil fungsi untuk menghancurkan semua NPC
        }
    }

    public void IncrementFallDownCount()
    {
        fallDownCount++;
    }

    private void DestroyAllNPCs()
    {
        foreach (GameObject npc in NPC_TeamArray)
        {
            Destroy(npc);
        }
    }
}
