using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnHome : MonoBehaviour
{

    public void GoLevelSelect()
    {
        SceneManager.LoadScene(1);
    }
}
