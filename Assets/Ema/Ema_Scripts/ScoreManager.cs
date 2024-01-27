using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public int score;
    public static ScoreManager instance;
    

    private void Awake()
    {
        if (instance == null || instance != this)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text += scoreToAdd;
        scoreText.text = "Score " + score;
    }

}
