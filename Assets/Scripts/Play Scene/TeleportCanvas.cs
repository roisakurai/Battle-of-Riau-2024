using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCanvas : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }
}
