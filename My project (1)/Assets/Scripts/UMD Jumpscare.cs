using System;
using System.Collections;
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

    

    public IEnumerator jumpscare()
    {
        if (!tutel.enabled)
        {
            tutel.enabled = true;
            sound.Play();
            yield return new WaitForSeconds(0.25f);
        }
        tutel.enabled = false;
        
        
    }
}
