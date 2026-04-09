using System;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public GameObject meteor;
    float time = 0f;
    float speed = .01f;
    bool meteorEvent = false;
    public float spawnx = -12f;
    public float spawny = 20f;
    public float spawnz = -10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meteor.SetActive(false);
        meteorEvent = true;
        meteor.transform.position = new Vector3(spawnx, spawny, spawnz);
    }

    void meteorDeleteAll()
    {
        // meteorEvent = false;
        meteor.SetActive(true);
        
        if (meteor.transform.position.y > 0)
        {
            Debug.Log("moving speed: "+ speed+ " y pos: " + meteor.transform.position.y);
            float x = meteor.transform.position.x + (speed * Time.deltaTime);
            float y = meteor.transform.position.y - (speed * Time.deltaTime);
            float z = meteor.transform.position.z + (speed * Time.deltaTime);;

            meteor.transform.position = new Vector3(x, y, z);
            if (speed < 25)
            {
                speed *= 1.05f;
            } else
            {
                speed += 1;
            }
            
        } else
        {
            meteorEvent = false;
            speed = .001f;
            meteor.SetActive(false);
            Debug.Log("floor hit");
        }

        // create a large explosion

        // Get all objects that were created
        // For each object created 
        // If it is NOT in the protected list, delete it
        // Otherwise, move on to the next iteration

    }

    // Update is called once per frame
    void Update()
    {
        if (meteorEvent) {
            meteorDeleteAll();
        }
    }
}
