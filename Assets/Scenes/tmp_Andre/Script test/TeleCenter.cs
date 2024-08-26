using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleCenter : MonoBehaviour
{
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(Time.deltaTime * 30, 0, 0));
    }

    void resetPlayer()
    {
        player.position = new Vector3(-7.49f, 12.572f, -8.22f);
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Damager"))
        {
            resetPlayer();
        }
    }
}
