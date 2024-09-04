using UnityEngine;
using UnityEngine.AI;

public class PatrolOnShip : MonoBehaviour
{
    public Transform[] patrolPoints;  // Array untuk menyimpan titik waypoint
    public float patrolSpeed = 3.5f;  // Variabel untuk mengatur kecepatan patroli

    private int currentPatrolIndex;   // Index waypoint yang sedang dituju
    private NavMeshAgent agent;       // Komponen NavMeshAgent

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Mengambil komponen NavMeshAgent
        agent.speed = patrolSpeed;            // Set kecepatan sesuai dengan variabel patrolSpeed
        currentPatrolIndex = 0;               // Mulai dari waypoint pertama
        
        if (patrolPoints.Length > 0)
        {
            agent.SetDestination(patrolPoints[currentPatrolIndex].position); // Menentukan tujuan pertama
        }
    }

    void Update()
    {
        // Jika prajurit sudah mencapai waypoint, maka lanjutkan ke waypoint berikutnya
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNextPatrolPoint();
        }
    }

    void GoToNextPatrolPoint()
    {
        // Jika tidak ada waypoint, return
        if (patrolPoints.Length == 0)
            return;

        // Pindah ke waypoint berikutnya
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;

        // Tentukan tujuan baru
        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
    }
}
