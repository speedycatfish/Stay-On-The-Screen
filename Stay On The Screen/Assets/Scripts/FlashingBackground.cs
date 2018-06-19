using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingBackground : MonoBehaviour
{
    Camera cam;
    Color red = new Color32(255, 0, 0, 255);
    Color blue = new Color32(0, 102, 255, 255);
    Color white = new Color32(255, 255, 255, 255);
    Color green = new Color32(0, 255, 65, 255);
    void Start()
    {
        cam = FindObjectOfType<Camera>();
    }
    void Update()
    {
        int colornum = Random.Range(1, 4);
        switch (colornum)
        {
            case 1:
                cam.backgroundColor = red;
                break;
            case 2:
                cam.backgroundColor = blue;
                break;
            case 3:
                cam.backgroundColor = white;
                break;
            case 4:
                cam.backgroundColor = green;
                break;

        }
    }
}
