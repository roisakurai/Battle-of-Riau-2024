/*using UnityEngine;

public class RayInteractor : MonoBehaviour
{
    public Teleport1 teleportScript1;
    public Teleport2 teleportScript2;

    void Update()
    {
        
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("TeleportTrigger1"))
                {
                    teleportScript1.Teleport();
                }
                else if (hit.collider.CompareTag("TeleportTrigger2"))
                {
                    teleportScript2.Teleport();
                }
            }
        }
    }
}
*/