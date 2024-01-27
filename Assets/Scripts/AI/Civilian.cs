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
        
        agent.SetDestination(new Vector3(newDestination.position.x,1,newDestination.position.z));
        
        
    }



}
