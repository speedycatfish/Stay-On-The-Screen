using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSelect : MonoBehaviour
{
    public Button[] buttonsarr;
    public void Start()
    {
        for (int i = 0; i < buttonsarr.Length; i++)
        {
            int x = i;
            buttonsarr[i].onClick.AddListener(delegate { SelectLevel(x + 1); });
        }
    }
    public void SelectLevel(int i)
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + i;
        SceneManager.LoadScene(nextSceneIndex);
    }
}

