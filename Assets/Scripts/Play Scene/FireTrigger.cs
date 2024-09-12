using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireTrigger : MonoBehaviour
{
    public GameObject[] fires; // Daftar game object api
    public GameObject[] soldiers; // Daftar prajurit di kapal
    public Transform[] teleportPoints; // Titik-titik teleport prajurit (di samping kapal)
    private NavMeshAgent[] navMeshAgents;
    private bool[] isTeleported;

    void Start()
    {
        // Inisialisasi arrays
        navMeshAgents = new NavMeshAgent[soldiers.Length];
        isTeleported = new bool[soldiers.Length];

        // Mendapatkan komponen NavMeshAgent untuk setiap prajurit
        for (int i = 0; i < soldiers.Length; i++)
        {
            navMeshAgents[i] = soldiers[i].GetComponent<NavMeshAgent>();
            isTeleported[i] = false;
        }
    }

    void Update()
    {
        // Iterasi melalui setiap api dan prajurit
        for (int i = 0; i < fires.Length; i++)
        {
            // Cek apakah api aktif dan prajurit terkait belum di-teleport
            if (fires[i].activeInHierarchy && !isTeleported[i])
            {
                // Nonaktifkan NavMeshAgent agar prajurit berhenti mengikuti NavMesh
                navMeshAgents[i].enabled = false;

                // Teleport prajurit ke titik yang ditentukan
                soldiers[i].transform.position = teleportPoints[i].position;

                // Tandai bahwa prajurit sudah di-teleport
                isTeleported[i] = true;
            }
        }
    }

    // Metode ini dipanggil ketika prajurit bertabrakan dengan objek lain
    private void OnTriggerEnter(Collider other)
    {
        // Cek apakah objek yang bertabrakan memiliki tag "Water"
        if (other.CompareTag("Water"))
        {
            // Cek apakah objek yang bertabrakan adalah salah satu prajurit
            for (int i = 0; i < soldiers.Length; i++)
            {
                if (other.gameObject == soldiers[i])
                {
                    // Hapus prajurit dari permainan
                    Destroy(soldiers[i]);
                }
            }
        }
    }
}
