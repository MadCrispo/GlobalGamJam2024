using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayer : MonoBehaviour
{
    private void Awake()
    {
         FindAnyObjectByType<Cinemachine.CinemachineVirtualCamera>().Follow=FindObjectOfType<PlayerManager>().transform;
    }
}
