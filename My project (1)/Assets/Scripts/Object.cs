using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
public class Objects : Entity, Plant
{
    public int maxObjects = 100; // limit for OBJECT spawn
    public static int totalObjects = 0;
    [SerializeField] Material daySky;
    [SerializeField] Material nightSky;

    public TextMeshPro msgMax;

    bool isDay = true;
    public bool MaxObjectReached(int totalObjects)
    {
        if (totalObjects > maxObjects)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
   
    // Throws error message when max capacity has been reached. 
    public IEnumerator MaxObjectThrowMSG()
    {
        string msg = "Max Objects reached. Can not spawn anymore. Please delete Objects before trying again.";
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

    void Sky()
    {
        if (isDay)
        {
            RenderSettings.skybox = nightSky;
        }
        else
        {
            RenderSettings.skybox = daySky;
        }
        isDay = !isDay;
    }

    // Spawns flowers (0 - 5) randomly and increment totalObjects. If Max reached, then throw message
    public void flower()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            if (MaxObjectReached(totalObjects) == false)
            {
                int x = Random.Range(0, 5);
                for (int y = 0; y < x; y++)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(Random.Range(-49f, 49f), 1, Random.Range(-49f, 49f));
                    totalObjects += x;
                }
            }
            else
            {
                StartCoroutine(MaxObjectThrowMSG());
            }
        }
    }
    // The rest follow a extremely similar format to FLOWER -> (GRASS/TREE/ROCK)
    public void grass()
    {
        if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            if (MaxObjectReached(totalObjects) == false)
            {
                int x = Random.Range(0, 5);
                for (int y = 0; y < x; y++)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(Random.Range(-49f, 49f), 1, Random.Range(-49f, 49f));
                    totalObjects += x;
                }
            }
            else
            {
                StartCoroutine(MaxObjectThrowMSG());
            }
        }
    }
    public void tree()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            if (MaxObjectReached(totalObjects) == false)
            {
                int x = Random.Range(0, 5);
                for (int y = 0; y < x; y++)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(Random.Range(-49f, 49f), 1, Random.Range(-49f, 49f));
                    totalObjects += x;
                }
            }
            else
            {
                StartCoroutine(MaxObjectThrowMSG());
            }
        }
    }
    public void rock()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            if (MaxObjectReached(totalObjects) == false)
            {
                int x = Random.Range(0, 5);
                for (int y = 0; y < x; y++)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(Random.Range(-49f, 49f), 1, Random.Range(-49f, 49f));
                    totalObjects += x;
                }
            }
            else
            {
                StartCoroutine(MaxObjectThrowMSG());
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Sky();
        }
    }

}