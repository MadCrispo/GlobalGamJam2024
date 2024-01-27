using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class MenuManager : MonoBehaviour
{
    public GameObject panel = null;
    public GameObject panelGame = null;
    public GameObject videoTrailler;
    public GameObject iconTitle;
    public static MenuManager menuManager;
    public TMP_InputField inputField;
    public string player_name;
    public GameObject playGameButton;
    public GameObject RulesPanel;

    private void Awake()
    {
        if(menuManager==null)
        {
            menuManager = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
       //conteinarButton.SetActive(false);
       //panelButton.SetActive(false);
        panel.SetActive(true);
        panelGame.SetActive(false);
        videoTrailler.SetActive(false);
        StartCoroutine(WaitBeforeShow());
    }

    public void SetPlayerName()
    {
        player_name = inputField.text;
        SceneManager.LoadSceneAsync("Game");
    }

    public void Game()
    {
        SceneManager.LoadScene(0);
    }
    private IEnumerator WaitBeforeShow()
    {
        yield return new WaitForSeconds(3);
        panel.SetActive(false);
        panelGame.SetActive(true);
       // yield return new WaitForSeconds(10);
       // videoTrailler.SetActive(true); 
       // iconTitle.SetActive(false);
    }
    public void ShowOpenButton(bool b)
    {
        playGameButton.SetActive(b);
    }
}
