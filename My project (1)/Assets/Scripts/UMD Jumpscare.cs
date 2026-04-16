using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class UMDJumpscare : MonoBehaviour
{
    public AudioSource sound;
    public MeshRenderer tutel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tutel = GetComponent<MeshRenderer>();
        sound = GetComponent<AudioSource>();
        tutel.enabled = false;
        sound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        Keyboard kb = Keyboard.current;
        if (kb == null) return;

        if (kb.uKey.isPressed)
        {
            tutel.enabled = true;
            sound.Play();
        }
        else
        {
            tutel.enabled = false;
        }
    }
}
