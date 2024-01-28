using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODOnAnimation : MonoBehaviour
{
    public void footstepsSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFXs/Player/Passi");
    }

}