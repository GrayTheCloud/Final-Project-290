using UnityEngine;

public class Predator : MonoBehaviour, Animal, Entity
{
    private int totalEntity = 0;  
    public int maxAnimals = 100; //limit for ANIMAL spawn
    public string msgMaxEntity = " ";

    public bool MaxEntityReached (int totalEntity)  
    {
        if (totalEntity > maxAnimals) 
            return true;
        else 
            return false;
    }

    public void MaxEntityThrowMSG() 
    {
        msgMaxEntity = "Max number of animals reached. Can not spawn anymore.\n";

        //display message on screen

        // Gameobject.text.setActive(true) to show message
        // Wait 2 seconds 
        // GameObject.message.setActive(false) to hide message
    }


    public void move()
    {
        throw new System.NotImplementedException();
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

    public void behavior()
    {
        throw new System.NotImplementedException();
    }
}
