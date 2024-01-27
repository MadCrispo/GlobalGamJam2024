using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODComunicazioni : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeBetweenComuncations());
    }



    IEnumerator TimeBetweenComuncations()
    {
        while (true)
        {
            yield return new WaitForSeconds(30f);
            GetComponent<FMODUnity.StudioEventEmitter>().Play();
            //il codice qui si ripeterà ogni X secondi 
        }

    }
}
