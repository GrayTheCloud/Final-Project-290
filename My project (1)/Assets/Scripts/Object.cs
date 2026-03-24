using UnityEngine;

public class Objects : MonoBehaviour, Plant, Entity
{
    private int totalEntity = 100;
     public int maxObjects = 100; //limit for OBJECT spawn
     public string msgMaxEntity = " ";

    public bool MaxEntityReached(int totalEntity)
    {
        if (totalEntity > maxObjects) 
            return true;
        else 
            return false;
    }
     public void MaxEntityThrowMSG() 
    {
        msgMaxEntity = "Max number of objects reached. Can not spawn anymore.\n";

        //display message on screen

        // Gameobject.text.setActive(true) to show message
        // Wait 2 seconds 
        // GameObject.message.setActive(false) to hide message
    }

    public void spawn()
    {
        if (MaxEntityReached (totalEntity)) { 

            // ~spawn code here~
            
            totalEntity++;

        } else //don't spawn anything if limit is reached
        {
            MaxEntityThrowMSG();
            return;
        }
    }

}
