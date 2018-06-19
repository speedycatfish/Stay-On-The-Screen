using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSelect : MonoBehaviour
{
    public Button[] buttonsarr;
    Color unlocked = new Color32(128, 128, 128, 255);
    Color locked = new Color32(10, 10, 10, 255);
    GameObject confirm;
    bool activated = false;
    public void Start()
    {
        confirm = GameObject.Find("Confirmation");
        confirm.SetActive(false);
        bool[] progress = PlayerPrefsX.GetBoolArray("progress", false, SceneManager.sceneCountInBuildSettings - 2);
        if (progress.Length < buttonsarr.Length)
        {
            progress = updateLevelCount(progress, buttonsarr.Length);
        }
        PlayerPrefsX.SetBoolArray("progress", progress);
        for (int i = 0; i < buttonsarr.Length; i++)
        {
            int x = i;
            if (x == 0 || progress[x] == true || progress[x - 1] == true)
            {
                buttonsarr[i].onClick.AddListener(delegate { SelectLevel(x + 1); });
                buttonsarr[i].GetComponent<Image>().color = unlocked;
            }
            else
            {
                buttonsarr[i].GetComponent<Image>().color = locked;
            }
        }
    }
    bool[] updateLevelCount(bool[] progress, int newlength)
    {
        bool[] newprogress = new bool[newlength];
        for (int i = 0; i < progress.Length; i++)
        {
            newprogress[i] = progress[i];
        }
        return newprogress;
    }
    public void SelectLevel(int i)
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + i;
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void ClearProgress()
    {
        bool[] progress = new bool[SceneManager.sceneCountInBuildSettings - 2];
        PlayerPrefsX.SetBoolArray("progress", progress);
        Start();
    }
    public void ActivateConfirmation()
    {
        Debug.Log("hi");
        activated = !activated;
        confirm.SetActive(activated);
    }
}

