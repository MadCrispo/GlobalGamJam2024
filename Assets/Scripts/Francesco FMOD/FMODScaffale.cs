using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODScaffale : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        GetComponent<FMODUnity.StudioEventEmitter>().Play();
    }
}
