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


    public void playSound()
    {
        sound.Play();
    }
}
