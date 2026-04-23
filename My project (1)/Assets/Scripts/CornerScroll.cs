using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections;

public class CornerScroll : MonoBehaviour
{

    public TMP_Text scrollText;

    public float cooldownTime = 0.5f;
    private float nextActionTime = 0f;

    string[] scroll = new string[4];

    public string[] labels = {"A:Alligator", "B.Bear", "C.Cat", "D.Dog", "E.Egg", "F.Flower",
    "G.Grass", "H.Hippo", "I.I", "J.Jaguar", "K.Kangaroo", "L.Lion", "M.Mouse",
    "N.Newt", "O.Ostrich", "P.Porcupine","Q.Quail", "R.Rock", "S.Sky",
    "T.Tree", "U.UMD", "V.Viper", "W.Weather", "X.X", "Y.Yak", "Z.Zebra"};

    public void addLabel(string key)
    {
        scroll[0] = scroll[1];
        //Debug.Log(scroll[1] + " is now at the top");
        scroll[1] = scroll[2];
        //Debug.Log(scroll[2] + " is now in the middle");
        scroll[2] = scroll[3];
        scroll[3] = key;
        //Debug.Log(scroll[2] + " is now at the bottom");
        //Debug.Log(scroll[0] + " " + scroll[1] + " " + scroll[2]);
        scrollText.text = scroll[0] + "\n" + scroll[1] + "\n" + scroll[2]+ "\n" + scroll[3];
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scroll[0] = "Hit keys!";
        scroll[1] = " ";
        scroll[2] = " ";
        scroll[3] = " ";
        scrollText.text = scroll[0] + "\n" + scroll[1] + "\n" + scroll[2]+ "\n" + scroll[3];
    }

    // Update is called once per frame
    // void Update()
    // {
    //     var kb = Keyboard.current;
    //     if (kb == null)
    //     {
    //         return;
    //     }
    //     if (Time.time >= nextActionTime)
    //     {
    //         if (kb.cKey.isPressed)
    //         {
    //             addLabel(labels[2]);
    //             nextActionTime = Time.time + cooldownTime;
    //         }
    //         if (kb.mKey.isPressed)
    //         {
    //             addLabel(labels[12]);
    //             nextActionTime = Time.time + cooldownTime;             
    //         }
    //         if (kb.aKey.isPressed)
    //         {
    //             addLabel(labels[0]);
    //             nextActionTime = Time.time + cooldownTime;           
    //         }
            
    //     }
    // }
}
