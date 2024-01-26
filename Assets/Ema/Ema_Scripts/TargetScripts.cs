using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TargetScripts : MonoBehaviour
{
    private ScoreManager gameManager;
    // Start is called before the first frame update

   

    public int pointValue;

    void Start()
    {

        gameManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Player"))
        {
            Debug.Log("Tocco i palazzi");
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }
    }
}





