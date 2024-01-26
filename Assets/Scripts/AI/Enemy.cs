using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Civilian
{
    public Transform playerTransform;

    public Transform oldDestination;

    public int secondToStartChase = 2;

    public int secondForLoseAggro = 3;

    public int alertPeriodDuration = 2;

    public bool inchase = false;
    
    public void setPlayerTransform(Transform playerPosition)
    {
        playerTransform = playerPosition;
        oldDestination = newDestination;
        ChasePlayer();
    }

    public void ChasePlayer()
    {
        inchase = true;
        if(playerTransform != null)
        {
            agent.SetDestination(playerTransform.position);
        }

    }

    public void ResetBehaviour()
    {
        newDestination = oldDestination;
        playerTransform = null;
        inchase = false;
    }

    protected override void LateUpdate()
    {
        if (!inchase)
        {
            base.LateUpdate();
        }

    }

}
