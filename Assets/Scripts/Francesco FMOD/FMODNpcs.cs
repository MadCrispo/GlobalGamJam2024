using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODNpcs : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(TimeBetweenMemes());
    }

    IEnumerator TimeBetweenMemes()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(7.0f, 12.0f));
            GetComponent<FMODUnity.StudioEventEmitter>().Play();
            //il codice qui si ripeterà ogni X secondi 
        }

    }
}
