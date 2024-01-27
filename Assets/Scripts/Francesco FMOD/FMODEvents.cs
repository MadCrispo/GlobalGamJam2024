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
        music = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Music");
        ambienceSFX = FMODUnity.RuntimeManager.CreateInstance("event:/SFXs/Ambiente/Supermercato");

        music.start();
        ambienceSFX.start();
    }

    public void Update()
    {
        //Gestione parametri diverse scene
        //reference temporanea alla scena attuale
        scene = SceneManager.GetActiveScene();
        //settaggio parametri dell'FMOD event music a seconda della scena: "MusicTransition" 0 = intro menu, 1 = start game, 2 = ending music, 3 = gameover stinger.
        music.getParameterByName("MusicTransition", out float val);

        if (scene.name == "FMODTest" && val != 1)
        {
            music.setParameterByName("MusicTransition", 1);
            //FIltro OFF nel menu
            //music.setParameterByName("PauseFilter", 1);
        }

        //else if (scene.name == "MenuIniziale" && val != 0)
        //{
        //    music.setParameterByName("MusicTransition", 0);
        //}
    }

    //effetto cutoff filtro dai parametri in FMOD (per stati pause e morte)
    public void AudioFilterFXOn()
    {
        music.setParameterByName("PauseFilter", 1);
    }
}
