using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    bool AutoRestart = true;

    private bool paused = false;
    public static GameObject PauseMenu;
    public void Start()
    {
        if (PauseMenu == null)
        {
            PauseMenu = GameObject.Find("PauseMenu");
        }
        PauseMenu.SetActive(false);
        Button[] buttons = PauseMenu.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            switch (buttons[i].name)
            {
                case "Resume":
                    buttons[i].onClick.AddListener(delegate { Pause(); });
                    break;
                case "Restart":
                    buttons[i].onClick.AddListener(delegate { PlayerDeath(); });
                    break;
                case "LevelSelect":
                    buttons[i].onClick.AddListener(delegate { GoLevelSelect(); });
                    break;
            }
        }
    }
    public void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Pause();
        }
        if (Input.GetButtonDown("Restart"))
        {
            PlayerDeath();
        }
    }
    public void Pause()
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
    public void PlayerDeath()
    {
        if (paused == true)
        {
            paused = !paused;
            Time.timeScale = 1f;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void GoLevelSelect()
    {
        if (paused == true)
        {
            paused = !paused;
            Time.timeScale = 1f;
        }
        SceneManager.LoadScene(1);
    }
}
