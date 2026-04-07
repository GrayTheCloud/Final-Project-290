using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class EntityHandler : MonoBehaviour
{
    // Move these to an entity handler class {
    // Tracks total # of entities spawned
    public int totalEntity = 0;
    // The text that holds error msg and will be shown when totalEntity > max capacity
    public TextMeshProUGUI msgMaxEntity;
    public List<GameObject> entities = new List<GameObject>();
    public GameObject[] prefabs;
    

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
        if (msgMaxEntity != null)
        {
            msgMaxEntity.text = msg;
            msgMaxEntity.gameObject.SetActive(true);
        }
        // Leave the text shown for 2 seconds
        yield return new WaitForSeconds(2f);
        // Hide the message now that 2 seconds have passed
        if (msgMaxEntity != null)
        {
            msgMaxEntity.gameObject.SetActive(false);
        }
    }

    // Spawn function to create and spawn all entities 
    public void spawn(int index)
    {
        // If capacity has not been reached, spawn Entity in the terrain and increment total
        if (MaxEntityReached(totalEntity) == false)
        {
            // TESTING SPAWNING WITH CUBE RIGHT NOW. CHANGE LATER
            GameObject spawned = GameObject.Instantiate(prefabs[index]);
            spawned.transform.position = new Vector3(Random.Range(-49f, 49f), 1, Random.Range(-49f, 49f));
            entities.Add(spawned);
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
        if (msgMaxEntity != null)
        {
            msgMaxEntity.gameObject.SetActive(false);
        }
    }

    // TESTING 
    void Update()
    {
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            spawn(0);
            if (MaxEntityReached(totalEntity))
            {
                StartCoroutine(MaxEntityThrowMSG());
            }
        }
        else if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            spawn(1);
            if (MaxEntityReached(totalEntity))
            {
                StartCoroutine(MaxEntityThrowMSG());
            }
        }
        else if (Keyboard.current.deleteKey.wasPressedThisFrame)
        {
            foreach (var entity in entities)
            {
                GameObject.Destroy(entity);
            }

            totalEntity = 0;
            entities.Clear();
            
        }
    }
    // }
}
