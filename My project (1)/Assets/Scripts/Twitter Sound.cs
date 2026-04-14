using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TwitterSound : MonoBehaviour
{
    public AudioSource sound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
       //can delete all the keyboard parts once we actually have a keyboard implemented
        var kb = Keyboard.current;
        if (kb == null) return;

        if (kb.xKey.isPressed)
        {
            sound.Play();
        } 
    }
}
