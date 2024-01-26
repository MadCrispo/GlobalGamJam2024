using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.SceneManagement;

public class FMODAudioManager : MonoBehaviour
{
    public static FMODAudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Debug.Log("Trovato più di un FMOD Event nella scena");
            Destroy(gameObject);
        }
    }

}
