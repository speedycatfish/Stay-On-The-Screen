using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroll : MonoBehaviour
{
    public float speed = 5f;

    private void FixedUpdate()
    {
        this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
