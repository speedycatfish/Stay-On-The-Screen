using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public static GameManager GM;
    public void Awake()
    {
        if (GM == null)
        {
            GM = FindObjectOfType<GameManager>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
        {
            GM.NextLevel();
        }
    }
}
