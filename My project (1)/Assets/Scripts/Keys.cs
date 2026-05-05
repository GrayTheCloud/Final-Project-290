using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.Windows.WebCam;

public class Keys : MonoBehaviour
{
    Utility util;
    EntityHandler entityHandler;
    public GameObject camBtn;
    CamBtn wcam;
    Dictionary<string, GameObject> dic;

    GameObject cornerScroll;

    CornerScroll scrollCode;
    private UMDJumpscare jumpscareScript;
    private TwitterSound playSoundScript;
    [SerializeField] SkyManager skyManager;

    void Start()
    {
        wcam = camBtn.GetComponent<CamBtn>();
        
        entityHandler = this.GetComponent<EntityHandler>();
        util = this.GetComponent<Utility>();  
        dic =  entityHandler.prefabs;
        jumpscareScript = GetComponent<UMDJumpscare>();
        playSoundScript = GetComponent<TwitterSound>();
        skyManager = FindObjectOfType<SkyManager>();
        cornerScroll = GameObject.Find("ScrollText");
        scrollCode = cornerScroll.GetComponent<CornerScroll>();
    }

    void keyCheck()
    {
        //if statements of doom
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[16]);
            entityHandler.spawn("quail");
        }
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[22]);
            //weather change
        }
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[4]);
            entityHandler.spawn("egg");
        }
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[17]);
            entityHandler.spawn("rock");
        }
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[19]);
            entityHandler.spawn("tree");
        }
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[24]);
            entityHandler.spawn("yak");
        }
        if (Keyboard.current.uKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[20]);
             //StartCoroutine(jumpscareScript.jumpscare());
        }
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            //open camera
            scrollCode.addLabel(scrollCode.labels[8]);
            wcam.camon = !(wcam.camon);
            if (wcam.camon)
            {
                wcam.RestartCam();
            } else
            {
                wcam.quad.SetActive(false);
            }
        }
        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[14]);
            entityHandler.spawn("ostrich");
        }
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[15]);
            entityHandler.spawn("porcupine");
        }
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
           scrollCode.addLabel(scrollCode.labels[0]); 
            entityHandler.spawn("alligator");
        }
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[18]);
            skyManager.Sky();
        }
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[3]);
            entityHandler.spawn("dog");
        }
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[5]);
            entityHandler.spawn("flower");
        }
        if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[6]);
            entityHandler.spawn("grass");
        }
        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[7]);
            entityHandler.spawn("hippo");
        }
        if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[9]);
            entityHandler.spawn("jaguar");
        }
        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[10]);
            entityHandler.spawn("kangaroo");
        }
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[11]);
            entityHandler.spawn("lion");
        }
        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[25]);
            entityHandler.spawn("zebra");
        }
        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[23]);
            //playSoundScript.playSound();
        }
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[2]);
            entityHandler.spawn("cat");
        }
        if (Keyboard.current.vKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[21]);
            entityHandler.spawn("viper");
        }
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[1]);
            entityHandler.spawn("bear");
        }
        if (Keyboard.current.nKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[13]);
            entityHandler.spawn("newt");
        }
        if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            scrollCode.addLabel(scrollCode.labels[12]);
            entityHandler.spawn("mouse");
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
