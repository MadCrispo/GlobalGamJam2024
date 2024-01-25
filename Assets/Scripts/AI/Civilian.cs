using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Civilian : MonoBehaviour
{
    
    public NavMeshAgent agent;

    public Transform newDestination;


    protected virtual void LateUpdate()
    {
        
        agent.SetDestination(newDestination.position);
        agent.gameObject.transform.forward = newDestination.position;
        
    }



}
