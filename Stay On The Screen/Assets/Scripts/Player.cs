using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameManager GM;
    [SerializeField]
    private Camera Cam;
    [SerializeField]
    private Transform RightCheck;
    [SerializeField]
    private Transform CeilingCheck;
    [SerializeField]
    private Transform LeftCheck;
    [SerializeField]
    private Transform GroundCheck;

    void Update()
    {
        Vector3 viewPos = Cam.WorldToViewportPoint(RightCheck.position);
        if (viewPos.x < 0)
        {
            GM.PlayerDeath();
        }
        viewPos = Cam.WorldToViewportPoint(LeftCheck.position);
        if (viewPos.x > 1)
        {
            GM.PlayerDeath();
        }
        viewPos = Cam.WorldToViewportPoint(CeilingCheck.position);
        if (viewPos.y < 0)
        {
            GM.PlayerDeath();
        }
        viewPos = Cam.WorldToViewportPoint(GroundCheck.position);
        if (viewPos.y > 1)
        {
            GM.PlayerDeath();
        }
    }

}
