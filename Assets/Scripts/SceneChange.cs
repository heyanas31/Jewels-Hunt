using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ClickSound()
    {
        AudioManager.instance.Play("Click");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel1()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("Level3");
    }
    public void LoadEnd()
    {
        SceneManager.LoadScene("TheEnd");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
