using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class soundOnOff : MonoBehaviour
{ 
    public GameObject soundonIcon, soundoffIcon;
    private bool muted = false;
    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateSoundIcon();
        AudioListener.pause = muted;
    }

    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        Save();
        UpdateSoundIcon();
    }

    private void UpdateSoundIcon()
    {
        if (muted == false)
        {
            soundonIcon.SetActive(true);
            soundoffIcon.SetActive(false);
        }
        else
        {
            soundonIcon.SetActive(false);
            soundoffIcon.SetActive(true);
        }
    }
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted",muted ? 1:0);
    }
}