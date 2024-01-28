using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificheScripts : MonoBehaviour
{
    public int countDownStartValue = 10;
    public TextMeshProUGUI Timetext;
    public GameObject PanelTutorial;
    public GameObject PanelMenu;

    // Start is called before the first frame update
    void Start()
    {
        countDownTimer();
        PanelMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void countDownTimer()
    {
        if (countDownStartValue > 0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);
            Timetext.text = "Timer : " + (int)countDownStartValue/*spanTime.Minutes + " : " + spanTime.Seconds*/;
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);
        }
        else
        {
            PanelMenu.SetActive(true);
            PanelTutorial.SetActive(false);
            
        }
    }
}
