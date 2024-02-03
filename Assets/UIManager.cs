using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private void Start()
    {
//        FMODEvents.instance.MusicToMenu();
    }
    public void LoadScene(int Level)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Level,LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
