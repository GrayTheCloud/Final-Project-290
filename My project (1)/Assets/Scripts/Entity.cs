using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;

public class Entity : MonoBehaviour
{
    public int totalEntity = 0;
    public TextMeshProUGUI msgMaxEntity;

    public bool MaxEntityReached(int totalEntity)
    {
        if (totalEntity > 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerator MaxEntityThrowMSG()
    {
        string msg = "Max Entity reached. Can not spawn anymore. Please delete Entities before trying again.";

        if (msgMaxEntity != null)
        {
            msgMaxEntity.text = msg;
            msgMaxEntity.gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(2f);

        if (msgMaxEntity != null)
        {
            msgMaxEntity.gameObject.SetActive(false);
        }
    }
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (msgMaxEntity != null)
        {
            msgMaxEntity.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.upArrowKey.isPressed)
        {
            totalEntity += 1;
           if (MaxEntityReached(totalEntity))
            {
                StartCoroutine(MaxEntityThrowMSG());
            }
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            totalEntity = 0;
        }
    }
}
