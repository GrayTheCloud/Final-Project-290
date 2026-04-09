using UnityEngine;
using UnityEngine.AI;

public class Predator : Entity, Animal
{
    public string preyType;
    public GameObject currentPrey = null;
    public NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
            chase(currentPrey.transform);
<<<<<<< Updated upstream
=======
            // Debug.Log(Vector3.Distance(transform.position, currentPrey.transform.position));
>>>>>>> Stashed changes
            if( Vector3.Distance(transform.position, currentPrey.transform.position) < 1.2)
            {
                currentPrey.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
<<<<<<< Updated upstream
=======
        // Debug.Log($"{collision.gameObject.name} has hit");
>>>>>>> Stashed changes
        if ( collision.gameObject.name == preyType)
        {
            collision.gameObject.SetActive(false);
        }
    }

}
