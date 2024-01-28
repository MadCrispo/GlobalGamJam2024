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

    public UnityEvent WinGame;
    public UnityEvent LoseGame;

    public void StopTime()
    {
        Time.timeScale = 0;
    }
}
