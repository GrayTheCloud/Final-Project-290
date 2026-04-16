using UnityEngine;
using UnityEngine.AI;

public class Prey : Entity, Animal
{
    public int maxAnimals = 100; //limit for ANIMAL spawn
    public string predatorType;
    public GameObject currentPredator = null;
    public NavMeshAgent agent;
    public Vector3[] wanderpoints;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = .2f;
        wanderpoints = new Vector3[8];
        for (int i = 0; i < wanderpoints.Length; i++)
        {
            wanderpoints[i] = new Vector3(
                UnityEngine.Random.Range(-50f, 50f),
                0,
                UnityEngine.Random.Range(-50f, 50f));

        }
    }

    public void behavior()
    {
        throw new System.NotImplementedException();
    }

    public void flee(Transform chaser)
    {
        Vector3 directionToMove = transform.position - chaser.position;
        Vector3 pointRunningTowards = transform.position + directionToMove.normalized * 10;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(pointRunningTowards, out hit, 10, NavMesh.AllAreas))
        {
            // Set the destination to the valid point on the NavMesh
            agent.SetDestination(hit.position);
        }
    }
    protected void Update()
    {
        currentPredator =  detectNearby(predatorType);
        if (currentPredator != null)
        {
            flee(currentPredator.transform);
        }
        else
        {
            wander();
        }
    }

    public void wander()
    {
        if (!agent.pathPending && agent.remainingDistance < agent.stoppingDistance)
        {
            int newDest = UnityEngine.Random.Range(0, 3);
            agent.SetDestination(wanderpoints[newDest]);
            Debug.Log("moving towards:" + agent.destination);
        }
    }
}
