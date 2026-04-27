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
    private CornerScroll scrollManager;
    [SerializeField] SkyManager skyManager;
   


    void Start()
    {
        entityHandler = this.GetComponent<EntityHandler>();
        util = this.GetComponent<Utility>();  
        dic =  entityHandler.prefabs;
        jumpscareScript = GetComponent<UMDJumpscare>();
        playSoundScript = GetComponent<TwitterSound>();
        skyManager = FindObjectOfType<SkyManager>();
        scrollManager = GameObject.Find("EmptyobjectForText").GetComponent<CornerScroll>();
    }

    //scrollManager.addLabel(scrollManager.labels[])

    void keyCheck()
    {
        //if statements of doom
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            entityHandler.spawn("quail");
            scrollManager.addLabel(scrollManager.labels[16]);
            }
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            //weather change
            scrollManager.addLabel(scrollManager.labels[22]);
        }
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            entityHandler.spawn("egg");
            scrollManager.addLabel(scrollManager.labels[4]);
            }
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            entityHandler.spawn("rock");
            scrollManager.addLabel(scrollManager.labels[17]);
            }
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            entityHandler.spawn("tree");
            scrollManager.addLabel(scrollManager.labels[19]);
            }
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            entityHandler.spawn("yak");
            scrollManager.addLabel(scrollManager.labels[24]);
            }
        if (Keyboard.current.uKey.wasPressedThisFrame)
        {
             //StartCoroutine(jumpscareScript.jumpscare());
             scrollManager.addLabel(scrollManager.labels[20]);
        }
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            //open camera
            scrollManager.addLabel(scrollManager.labels[8]);
        }
        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            entityHandler.spawn("ostrich");
            scrollManager.addLabel(scrollManager.labels[14]);
            }
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            entityHandler.spawn("porcupine");
            scrollManager.addLabel(scrollManager.labels[15]);
        }
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            entityHandler.spawn("alligator");
            scrollManager.addLabel(scrollManager.labels[0]);
        }
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            skyManager.Sky();
            scrollManager.addLabel(scrollManager.labels[18]);
        }
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            entityHandler.spawn("dog");
            scrollManager.addLabel(scrollManager.labels[3]);
        }
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            entityHandler.spawn("flower");
            scrollManager.addLabel(scrollManager.labels[5]);
        }
        if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            entityHandler.spawn("grass");
            scrollManager.addLabel(scrollManager.labels[6]);
        }
        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            entityHandler.spawn("hippo");
            scrollManager.addLabel(scrollManager.labels[7]);
        }
        if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            entityHandler.spawn("jaguar");
            scrollManager.addLabel(scrollManager.labels[9]);
        }
        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            entityHandler.spawn("kangaroo");
            scrollManager.addLabel(scrollManager.labels[10]);
        }
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {entityHandler.spawn("lion");
        scrollManager.addLabel(scrollManager.labels[11]);
        }
        if (Keyboard.current.zKey.wasPressedThisFrame)
        {entityHandler.spawn("zebra");
        scrollManager.addLabel(scrollManager.labels[25]);
        }
        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            //playSoundScript.playSound();
            scrollManager.addLabel(scrollManager.labels[23]);
        }
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {entityHandler.spawn("cat");
        scrollManager.addLabel(scrollManager.labels[2]);}
        if (Keyboard.current.vKey.wasPressedThisFrame)
        {entityHandler.spawn("viper");
        scrollManager.addLabel(scrollManager.labels[22]);
        }
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {entityHandler.spawn("bear");
        scrollManager.addLabel(scrollManager.labels[1]);
        }
        if (Keyboard.current.nKey.wasPressedThisFrame)
        {entityHandler.spawn("newt");
        scrollManager.addLabel(scrollManager.labels[13]);
        }
        if (Keyboard.current.mKey.wasPressedThisFrame)
        {entityHandler.spawn("mouse");
        scrollManager.addLabel(scrollManager.labels[12]);
        }

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
