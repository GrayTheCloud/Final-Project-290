using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;

public class Entity : MonoBehaviour
{
    public EntityHandler handler;
    public float detectionDistance;

    // Move these to an entity handler class {
        // Tracks total # of entities spawned
        public static int totalEntity = 0;
        // The text that holds error msg and will be shown when totalEntity > max capacity
        public TextMeshProUGUI msgMax;

        // Checks to see whether max capacity has been reached
        public bool MaxEntityReached(int totalEntity)
        {
            if (totalEntity > 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Throws error message when max capacity has been reached. 
        public IEnumerator MaxEntityThrowMSG()
        {
            string msg = "Max Entity reached. Can not spawn anymore. Please delete Entities before trying again.";
            // Set the error message to msg and show the text
            if (msgMax != null)
            {
                msgMax.text = msg;
                msgMax.gameObject.SetActive(true);
            }
            // Leave the text shown for 2 seconds
            yield return new WaitForSeconds(2f);
            // Hide the message now that 2 seconds have passed
            if (msgMax != null)
            {
                msgMax.gameObject.SetActive(false);
            }
        }

        // Spawn function to create and spawn all entities 
        public void spawn()
        {
            // If capacity has not been reached, spawn Entity in the terrain and increment total
            if (MaxEntityReached (totalEntity) == false) 
            { 
                // TESTING SPAWNING WITH CUBE RIGHT NOW. CHANGE LATER
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(Random.Range(-49f, 49f), 1, Random.Range(-49f, 49f));
                totalEntity++;
                return;
            } 
            // Throw error message on screen
            else 
            {
                StartCoroutine(MaxEntityThrowMSG());
                return;
            }
        }

        // TESTING 
        void Start()
        {
            if (msgMax == null)
            {
                msgMax.gameObject.SetActive(false);
            }

            handler = FindFirstObjectByType<EntityHandler>();
        }

        // TESTING 
        void Update()
        {
            if (Keyboard.current.upArrowKey.wasPressedThisFrame)
            {
                spawn();
                if (MaxEntityReached(totalEntity))
                {
                    StartCoroutine(MaxEntityThrowMSG());
                }
            }
            else if (Keyboard.current.downArrowKey.wasPressedThisFrame)
            {
                totalEntity = 0;
            }
        }
    // }
    public void move()
    {
        throw new System.NotImplementedException();
    }



    public GameObject detectNearby( string targetname)
    {
        GameObject target = null;
        var colliders = Physics.OverlapSphere(transform.position, detectionDistance);
        foreach (var collider in colliders)
        {
            //Debug.Log($"{collider.gameObject.name} is nearby");
            if(collider.gameObject.name.Contains(targetname))
            {
                target = collider.gameObject;
                break;
            }
        }
        return target;
    }
}