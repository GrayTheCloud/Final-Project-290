using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Keys : MonoBehaviour
{
    Utility util;
    EntityHandler entityHandler;
    Dictionary<string, GameObject> dic;

    private UMDJumpscare jumpscareScript;
    private TwitterSound playSoundScript;
    [SerializeField] SkyManager skyManager;

    void Start()
    {
        entityHandler = this.GetComponent<EntityHandler>();
        util = this.GetComponent<Utility>();  
        dic =  entityHandler.prefabs;
        jumpscareScript = GetComponent<UMDJumpscare>();
        playSoundScript = GetComponent<TwitterSound>();
        skyManager = FindObjectOfType<SkyManager>();
    }

    void keyCheck()
    {
        //if statements of doom
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            entityHandler.spawn("quail");
            }
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            //weather change
        }
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            entityHandler.spawn("egg");
            }
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            entityHandler.spawn("rock");
            }
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            entityHandler.spawn("tree");
            }
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            entityHandler.spawn("yak");
            }
        //if (Keyboard.current.uKey.wasPressedThisFrame)
        //{
             //StartCoroutine(jumpscareScript.jumpscare());
        //}
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            //open camera
        }
        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            entityHandler.spawn("ostrich");
            }
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            entityHandler.spawn("porcupine");
        }
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            entityHandler.spawn("alligator");
        }
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            skyManager.Sky();
        }
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            entityHandler.spawn("dog");
        }
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            entityHandler.spawn("flower");
        }
        if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            entityHandler.spawn("grass");
        }
        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            entityHandler.spawn("hippo");
        }
        if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            entityHandler.spawn("jaguar");
        }
        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            entityHandler.spawn("kangaroo");
        }
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {entityHandler.spawn("lion");
        }
        if (Keyboard.current.zKey.wasPressedThisFrame)
        {entityHandler.spawn("zebra");
        }
        //if (Keyboard.current.xKey.wasPressedThisFrame)
        //{
            //playSoundScript.playSound();
        //}
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {entityHandler.spawn("cat");}
        if (Keyboard.current.vKey.wasPressedThisFrame)
        {entityHandler.spawn("viper");
        }
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {entityHandler.spawn("bear");
        }
        if (Keyboard.current.nKey.wasPressedThisFrame)
        {entityHandler.spawn("newt");
        }
        if (Keyboard.current.mKey.wasPressedThisFrame)
        {entityHandler.spawn("mouse");}

        if (Keyboard.current.backspaceKey.wasPressedThisFrame)
        {
            //meteor event triggered
            if (!util.meteorEvent)
            {
                StartCoroutine(util.meteorDeleteAll());
            }
        }

    }

    void Update()
    {
        keyCheck();
    }
}
