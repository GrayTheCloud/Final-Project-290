using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;

public abstract class Entity : MonoBehaviour
{
    public float detectionDistance;

 
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
