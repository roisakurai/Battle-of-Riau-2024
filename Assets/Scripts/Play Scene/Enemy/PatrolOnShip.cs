// using UnityEngine;
// using UnityEngine.AI;

// public class PatrolOnShip : MonoBehaviour
// {
//     public Transform[] patrolPoints;  // Array untuk menyimpan titik waypoint
//     public float patrolSpeed = 3.5f;  // Variabel untuk mengatur kecepatan patroli

//     private int currentPatrolIndex;   // Index waypoint yang sedang dituju
//     private NavMeshAgent agent;       // Komponen NavMeshAgent

//     void Start()
//     {
//         agent = GetComponent<NavMeshAgent>(); // Mengambil komponen NavMeshAgent
//         agent.speed = patrolSpeed;            // Set kecepatan sesuai dengan variabel patrolSpeed
//         currentPatrolIndex = 0;               // Mulai dari waypoint pertama
        
//         if (patrolPoints.Length > 0)
//         {
//             agent.SetDestination(patrolPoints[currentPatrolIndex].position); // Menentukan tujuan pertama
//         }
//     }

//     void Update()
//     {
//         // Jika prajurit sudah mencapai waypoint, maka lanjutkan ke waypoint berikutnya
//         if (!agent.pathPending && agent.remainingDistance < 0.5f)
//         {
//             GoToNextPatrolPoint();
//         }
//     }

//     void GoToNextPatrolPoint()
//     {
//         // Jika tidak ada waypoint, return
//         if (patrolPoints.Length == 0)
//             return;

//         // Pindah ke waypoint berikutnya
//         currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;

//         // Tentukan tujuan baru
//         agent.SetDestination(patrolPoints[currentPatrolIndex].position);
//     }
// }
using UnityEngine;
using UnityEngine.AI;

public class PatrolOnShip : MonoBehaviour
{
    public float patrolSpeed = 3.5f;         // Variabel untuk mengatur kecepatan patroli
    public float walkRadius = 10f;           // Radius untuk menentukan seberapa jauh agent bisa berjalan secara acak
    public Transform movingPlatform;         // Transform dari platform yang bergerak (kapal, dll.)

    private NavMeshAgent agent;              // Komponen NavMeshAgent
    private Vector3 lastPlatformPosition;    // Posisi terakhir dari platform yang bergerak

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Mengambil komponen NavMeshAgent
        agent.speed = patrolSpeed;            // Set kecepatan sesuai dengan variabel patrolSpeed

        // Simpan posisi awal platform yang bergerak
        lastPlatformPosition = movingPlatform.position;

        // Tentukan tujuan acak pertama
        SetRandomDestination();
    }

    void Update()
    {
        // Kompensasi pergerakan platform yang bergerak
        Vector3 platformDelta = movingPlatform.position - lastPlatformPosition;
        transform.position += platformDelta;

        // Simpan posisi platform terbaru
        lastPlatformPosition = movingPlatform.position;

        // Jika agent sudah mencapai tujuan, pilih tujuan acak berikutnya
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            SetRandomDestination();
        }
    }

    void SetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;  // Pilih titik acak dalam radius
        randomDirection += transform.position;                           // Tambahkan titik acak ke posisi saat ini

        NavMeshHit hit;
        // Cek apakah titik tersebut berada di atas NavMesh
        if (NavMesh.SamplePosition(randomDirection, out hit, walkRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);  // Tentukan tujuan baru pada posisi yang valid di NavMesh
        }
    }
}
