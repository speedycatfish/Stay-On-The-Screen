using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
    [SerializeField]
    bool AutoRestart = true;

    public void PlayerDeath(){
        if (AutoRestart == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void NextLevel(){
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
