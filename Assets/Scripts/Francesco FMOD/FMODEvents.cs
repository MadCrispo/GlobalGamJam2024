using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.SceneManagement;

public class FMODEvents : MonoBehaviour
{
    //istanza singleton
    public static FMODEvents instance;
    //gestione scene
    private Scene scene;

    //Tutte le musiche saranno gestite dai paramteri in FMOD
    public EventInstance music;
    //Tutti gli ambienti saranno gestiti dai paramteri in FMOD
    public EventInstance ambienceSFX;

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

    public void Start()
    {
        //creazione delle instance FMOD (loop)
        music = FMODUnity.RuntimeManager.CreateInstance("event:/Musica/Music");
        //ambienceSFX = FMODUnity.RuntimeManager.CreateInstance("event:/Musica/LoopMusicLevel");
        music.start();
    }

    public void Update()
    {
        //Gestione parametri diverse scene
        //reference temporanea alla scena attuale
        scene = SceneManager.GetActiveScene();
        //settaggio parametri dell'FMOD event music a seconda della scena:
        music.getParameterByName("TransizioneScene", out float val);

        if (scene.name == "FMOD Test1" && val != 0)
        {
            //valore parametro FMOD "TransizioneScene" 0 = menù:
            music.setParameterByName("TransizioneScene", 0);
            //FIltro OFF nel menu
            music.setParameterByName("PauseFilter", 0);
        }
        else if (scene.name == "gino" && val != 1)
        {
            //valore parametro FMOD "TransizioneScene" 1 = level1:
            music.setParameterByName("TransizioneScene", 1);
        }
    }

    //effetto cutoff filtro dai parametri in FMOD (per stati pause e morte)
    public void AudioFilterFXOn()
    {
        music.setParameterByName("PauseFilter", 1);
    }
}
