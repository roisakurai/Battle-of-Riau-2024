using UnityEngine;
using UnityEngine.AI;

public class BirdAI : MonoBehaviour
{
    public Transform[] targetPoints;
    private int currentTargetIndex;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (targetPoints.Length > 0)
        {
            SetRandomTarget();
        }
        else
        {
            Debug.LogError("Assign target points to the FlyingBirdAI script.");
        }
    }

    void Update()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f)
        {
            SetRandomTarget();
        }
    }

    void SetRandomTarget()
    {
        int randomIndex = Random.Range(0, targetPoints.Length);
        currentTargetIndex = randomIndex;

        navMeshAgent.SetDestination(targetPoints[currentTargetIndex].position);
    }
}
