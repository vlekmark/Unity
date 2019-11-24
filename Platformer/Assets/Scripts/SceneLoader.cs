using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int currentSceneIndex;
    private int levelsUnlocked = 0;

    public Button[] buttons;

    public void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int i = buttons.Length;
        for (int j = 0; j <= i; j++)
        {
            buttons[j].GetComponent<Button>().interactable = false;
            CheckProgress();
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadLastScene()
    {
        SceneManager.LoadScene("lastScene");
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Lvl1");
    }
    public void QuitApplication()
    {
        Application.Quit();
    }

    public void CheckProgress() 
    {
        levelsUnlocked = PlayerPrefs.GetInt("LevelsUnlocked");

        for (int k = 0; k <= levelsUnlocked; k++)
        {
            buttons[k].GetComponent<Button>().interactable = true;
        }
    }
}
