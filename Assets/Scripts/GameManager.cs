using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int coincount;
    public TextMeshProUGUI cointext;
    public GameObject Player, PauseButton, blureffect;
    public GameObject YellowClock, RedClock;
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] float RemainingTime;
    public static bool isGameOver;
    public static bool isGameWin;
    private bool firstescape;
    public GameObject LooseScreen;
    public GameObject WinScreen;
    public GameObject PauseScreen;

    private void Awake()
    {
        isGameOver = false;
        isGameWin = false;
    }
    void Start()
    {
        coincount = 0;
        firstescape = true;
        PauseScreen.SetActive(false);
        LooseScreen.SetActive(false);
        WinScreen.SetActive(false);
    }

    private void Timer()
    {
        if (RemainingTime > 0)
        {
            RemainingTime -= Time.deltaTime;
            if (RemainingTime < 11) //0-10 will red
            {
                TimerText.color = Color.red;
                YellowClock.SetActive(false);
                RedClock.SetActive(true);
            }
        }
        else if (RemainingTime <= 1)
        {
            isGameOver = true;
            Player.SetActive(false);
            AudioManager.instance.Play("YouLose");
            RemainingTime = 0;
        }
        int minutes = Mathf.FloorToInt(RemainingTime / 60);
        int seconds = Mathf.FloorToInt(RemainingTime % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    void Update()
    {
        cointext.text = coincount.ToString();

        if (isGameWin)
        {
            WinScreen.SetActive(true);
            blureffect.SetActive(true);
            Player.SetActive(false);
            PauseButton.SetActive(false);
        }
        else if (isGameOver)
        {
            LooseScreen.SetActive(true);
            blureffect.SetActive(true);
            PauseButton.SetActive(false);
        }
        else
        {
            Timer();
        }
        EscapeKeyCheck();
    }

    public void PauseGame()
    {
        PauseScreen.SetActive(true);
        blureffect.SetActive(true);
        Time.timeScale = 0;
    }
    public void UnPauseGame()
    {
        PauseScreen.SetActive(false);
        blureffect.SetActive(false);
        Time.timeScale = 1;
    }

    private void EscapeKeyCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && firstescape && !isGameOver && !isGameWin)
        {
            firstescape = false;
            PauseGame();
            PauseButton.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !firstescape && !isGameOver && !isGameWin)
        {
            firstescape = true;
            UnPauseGame();
            PauseButton.SetActive(true);
        }
    }

}
