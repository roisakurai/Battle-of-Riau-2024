using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireTrigger : MonoBehaviour
{
    public GameObject[] fires; // Daftar game object api
    public GameObject[] soldiers; // Daftar prajurit di kapal
    public Transform[] teleportPoints; // Titik-titik teleport prajurit (di samping kapal)
    public float fallSpeed = 0.1f; // Kecepatan jatuh prajurit, semakin kecil nilai semakin lambat
    public float fallHeight = 5f; // Ketinggian jatuh untuk prajurit

    private NavMeshAgent[] navMeshAgents;
    private bool[] isTeleported;
    private bool[] isFalling;

    void Start()
    {
        // Inisialisasi arrays
        navMeshAgents = new NavMeshAgent[soldiers.Length];
        isTeleported = new bool[soldiers.Length];
        isFalling = new bool[soldiers.Length];

        // Mendapatkan komponen NavMeshAgent untuk setiap prajurit
        for (int i = 0; i < soldiers.Length; i++)
        {
            navMeshAgents[i] = soldiers[i].GetComponent<NavMeshAgent>();
            isTeleported[i] = false;
            isFalling[i] = false;
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

                // Tandai bahwa prajurit sudah di-teleport dan mulai jatuh
                isTeleported[i] = true;
                isFalling[i] = true;
            }

            // Jika prajurit mulai jatuh
            if (isFalling[i])
            {
                // Pindahkan prajurit ke bawah dengan kecepatan yang lebih lambat dan terkontrol
                float newY = Mathf.Lerp(soldiers[i].transform.position.y, soldiers[i].transform.position.y - fallHeight, fallSpeed * Time.deltaTime);
                soldiers[i].transform.position = new Vector3(soldiers[i].transform.position.x, newY, soldiers[i].transform.position.z);
            }
        }
    }

    // Metode ini dipanggil ketika prajurit bertabrakan dengan objek lain
    private void OnCollisionEnter(Collision collision)
    {
        // Cek apakah objek yang bertabrakan memiliki tag "Water"
        if (collision.gameObject.CompareTag("Water"))
        {
            // Cek apakah objek yang bertabrakan adalah salah satu prajurit
            for (int i = 0; i < soldiers.Length; i++)
            {
                if (collision.gameObject == soldiers[i])
                {
                    // Mulai coroutine untuk menghancurkan prajurit setelah 1 detik
                    StartCoroutine(DestroyAfterDelay(soldiers[i], 1f));
                }
            }
        }
    }

    // Coroutine untuk menghancurkan game object setelah delay
    private IEnumerator DestroyAfterDelay(GameObject soldier, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(soldier);
    }
}
