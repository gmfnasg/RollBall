using UnityEngine;
using System.Collections;

public class Webcam : MonoBehaviour {

    void Start()
    {
        WebCamTexture c = new WebCamTexture();
        GetComponent<Renderer>().material.mainTexture = c; // 將目前物體貼圖換成攝影機貼圖
        c.Play();
    }
}
