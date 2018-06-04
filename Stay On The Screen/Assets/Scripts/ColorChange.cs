using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorChange : MonoBehaviour
{
    int a = 0;
    int b = 0;
    int c = 0;
    Color flashing = new Color(0, 0, 0, 255);

    void Update()
    {
        a = (int)Random.Range(0, 255);
        b = (int)Random.Range(0, 255);
        c = (int)Random.Range(0, 255);

        //Debug.Log(a + " " + b + " " + c);
        flashing = new Color32((byte)a, (byte)b, (byte)c, 255);
        this.GetComponent<Image>().color = flashing;
    }
}



