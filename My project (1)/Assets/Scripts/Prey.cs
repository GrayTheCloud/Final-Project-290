using UnityEngine;
using UnityEngine.AI;

public class Prey : Entity, Animal
{
    public int maxAnimals = 100; //limit for ANIMAL spawn
    public string predatorType;
    public GameObject currentPredator = null;
    public NavMeshAgent agent;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
    }
}
