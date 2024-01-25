using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Civilian : MonoBehaviour
{
    
    public NavMeshAgent agent;

    public Transform newDestination;


    void LateUpdate()
    {
        agent.SetDestination(newDestination.position);
    }



}
