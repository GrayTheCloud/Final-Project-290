using System;
using UnityEditor;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public GameObject meteor;
    EntityHandler entityHandler;
    float speed = .01f;

    //make true to trigger meteor event
    public bool meteorEvent = false;
    public GameObject cam;
    public float spawnx = -12f;
    public float spawny = 20f;
    public float spawnz = -10f;
    float intensity = .01f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        entityHandler = this.GetComponent<EntityHandler>();

        //meteor initial position + hidden
        meteor.SetActive(false);
        meteorEvent = true;
        meteor.transform.position = new Vector3(spawnx, spawny, spawnz);
    }

    void meteorDeleteAll()
    {
        meteor.SetActive(true);
        
        if (meteor.transform.position.y > 0)
        {
            //camera shake 
            cam.transform.position = new Vector3(UnityEngine.Random.Range(-intensity,intensity), UnityEngine.Random.Range(-intensity,intensity), UnityEngine.Random.Range(-intensity,intensity));
            if (intensity < .85f)
            {
                intensity += intensity * Time.deltaTime * 1.15f;
            }
            
            // move meteor
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
            meteor.SetActive(false);

            //camera shake slows to a stop
            if (intensity > .01f)
            {
                intensity -= intensity * Time.deltaTime * 4f;
                cam.transform.position = new Vector3(UnityEngine.Random.Range(-intensity,intensity), UnityEngine.Random.Range(-intensity,intensity), UnityEngine.Random.Range(-intensity,intensity));
                return;
            }

            //reset 
            meteorEvent = false;
            speed = .01f;
            intensity = .01f;
            cam.transform.position = new Vector3(0,0,0);
            meteor.SetActive(false);
            
            // create a large explosion

            
            //note: any entities NOT created with spawn() will not delete
            entityHandler.destroy();
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (meteorEvent) {
            meteorDeleteAll();
        }
    }
}
