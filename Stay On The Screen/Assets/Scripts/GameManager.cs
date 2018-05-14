using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    bool AutoRestart = true;

    private bool paused = false;
    public static GameObject PauseMenu;
    public void Awake()
    {
        if (PauseMenu == null)
        {
            PauseMenu = GameObject.Find("PauseMenu");
        }
        PauseMenu.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
            if (paused == true)
            {
                Time.timeScale = 0f;
                PauseMenu.SetActive(true);
            }
            else
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }
    public void PlayerDeath()
    {
        if (AutoRestart == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
