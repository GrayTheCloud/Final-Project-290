using System;
using UnityEngine;
using UnityEngine.AI;

public class Predator : Entity, Animal
{
    public string preyType;
    public GameObject currentPrey = null;
    public NavMeshAgent agent;
    public Vector3[] wanderpoints;
    private bool preyDetected;
    public GameObject exclam;


    private void Start()
    {
        handler = FindFirstObjectByType<EntityHandler>();
        exclam?.SetActive(false);
        preyDetected = false;
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

    public void chase(Transform target)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(target.position, out hit, 10, NavMesh.AllAreas))
        {
            // Set the destination to the valid point on the NavMesh
            agent.SetDestination(hit.position);
        }
    }

    protected void Update()
    {
        currentPrey = detectNearby(preyType);
        if (currentPrey != null)
        {
            if (!exclam.activeSelf)
            {
                exclam.SetActive(true);
            }
            chase(currentPrey.transform);
            
            if( Vector3.Distance(transform.position, currentPrey.transform.position) < 1.2)
            {
                //currentPrey.SetActive(false);
                handler.despawn(currentPrey);
            }
        } else
        {
            if (exclam.activeSelf)
            {
                exclam.SetActive(false);
            }
            wander();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.name == preyType)
        {
            collision.gameObject.SetActive(false);
        }
    }

    public void wander()
    {
        if(!agent.pathPending && agent.remainingDistance < agent.stoppingDistance)
        {
            int newDest = UnityEngine.Random.Range(0, 3);
            agent.SetDestination(wanderpoints[newDest]);
            Debug.Log("moving towards:" + agent.destination);
        }

    }
}
