using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gamemanager : MonoBehaviour
{
    public static bool CanBuy = false;
    public static Gamemanager instance;
    public  TMPro.TextMeshProUGUI who;
    private void Awake()
    {
        if (instance == null)   
            instance = this;    
    }

    public void Start()
    {
        StartGame();
    }

    public UnityEvent WinGame;
    public UnityEvent LoseGame;

    public void StopTime()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        FMODEvents.instance.MusicToStart();
    }

    public void FinalTime()
    {
        FMODEvents.instance.MusicToEnding();
    }

    public void LostGame()
    {
        FMODEvents.instance.MusicToDefeat();
    }

    public void GotoMenu()
    {
        FMODEvents.instance.MusicToMenu();
    }
}
