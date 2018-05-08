using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public static GameManager GM;
    public void Awake()
    {Matrix4x4
        if(GM == null){
            GM = FindObjectOfType<GameManager>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
        {
            GM.PlayerDeath();
        }
    }
}
