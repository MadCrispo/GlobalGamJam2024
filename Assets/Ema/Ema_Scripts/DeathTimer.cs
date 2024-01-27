using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DeathTimer : MonoBehaviour
{
    public TextMeshProUGUI Timetext;
    public float death = 20f;
    float titme;

    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject panelTimer;
    int countDownStartValue = 10;
    public bool gameOver = false;
    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        countDownTimer();
    }

    // Update is called once per frame
    void Update()
    {
       // titme += Time.deltaTime;
        //minute=(int)(death - (int)titme)/60;
        //seconds=(int)(death - (int)titme)-minute*60;
        //Timetext.text = minute.ToString() +":"+seconds.ToString();
        //Timetext.text = ((int)death - (int)titme).ToString();
        //if (death<1)
        //{
        //    Time.timeScale = 0f;
        //    gameOver = true;
        //    panelTimer.SetActive(false);
        //    losePanel.SetActive(true);


        //}
    }

    void countDownTimer()
    {
        if (countDownStartValue > 0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);
            Timetext.text = "Timer : " + spanTime.Minutes + " : " + spanTime.Seconds;
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);
        }
        else
        {
            Timetext.text = "GameOver!";
            panelTimer.SetActive(false);
            losePanel.SetActive(true);
        }
    }
}
