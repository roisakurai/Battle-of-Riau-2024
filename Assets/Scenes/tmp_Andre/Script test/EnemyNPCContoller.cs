using UnityEngine;

public class EnemyNPCContoller : MonoBehaviour
{
    public string npcTag = "NPC"; // Tag NPC
    private GameObject nearestNPC; // NPC terdekat

    // Update is called once per frame
    void Update()
    {
        FindNearestNPC();

        if (nearestNPC != null)
        {
            // Menghitung arah ke NPC terdekat
            Vector3 direction = nearestNPC.transform.position - transform.position;
            direction.y = 0f;

            // Rotasi karakter untuk menghadap ke arah NPC terdekat
            if (direction != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * 180f);
            }
        }
    }

    void FindNearestNPC()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag(npcTag);
        float nearestDistance = Mathf.Infinity;

        foreach (GameObject npc in npcs)
        {
            float distance = Vector3.Distance(transform.position, npc.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestNPC = npc;
            }
        }
    }
}
