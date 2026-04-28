using System;
using UnityEngine;

public class CamBtn : MonoBehaviour
{
    public GameObject quad;
    public bool camon = false;
    static WebCamTexture cam;
    Texture2D tex;
    Color32[] pixels;
    Action update = () => { };

    void Start()
    {
        quad.SetActive(false);   
        camon = false;          

        update = WaitingForCam; 
    }

    void Update()
    {
        //only run cam if its on
        if (!camon) return;

        update(); 
    }
    
    void WaitingForCam()
    {
        if (!cam.didUpdateThisFrame) return;

        pixels = new Color32[cam.width * cam.height];
        tex = new Texture2D(cam.width, cam.height, TextureFormat.RGBA32, false);

        update = CamIsOn;

        //Debug.Log("Camera ready");
    }

    void CamIsOn()
    {
        if (!cam.didUpdateThisFrame) return;

        cam.GetPixels32(pixels);

        tex.SetPixels32(pixels);
        tex.Apply();
        GetComponent<Renderer>().material.mainTexture = tex;
    }

    public void RestartCam()
    {
        //turn cam on
        quad.SetActive(true);

        //reset everything
        pixels = null;
        tex = null;

        update = WaitingForCam;

        if (cam == null)
        {
            cam = new WebCamTexture();
        }

        if (!cam.isPlaying)
        {
            cam.Play();
        }

        GetComponent<Renderer>().material.mainTexture = cam;
    }
}