using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void LoadScene(int Level)
    {
        SceneManager.LoadScene(Level,LoadSceneMode.Single);
    }
}
