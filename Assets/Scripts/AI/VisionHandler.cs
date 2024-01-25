using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VisionHandler : MonoBehaviour
{
    [SerializeField]
    private Enemy me;
    public bool hasSeen = false;
    public bool recentLostSight = false;
    private GameObject spottedGameObject= null;


    private void OnTriggerEnter(Collider other)
    {
        spottedGameObject = other.gameObject;
        if (recentLostSight)
        {
            setChaseToStart(spottedGameObject);
        }
        else
        {
            me.agent.isStopped = true;
            
            StartCoroutine(WaitForSpot(spottedGameObject));
        }
        
       
    }

    IEnumerator WaitForSpot(GameObject c)
    {
        yield return new WaitForSeconds(me.secondToStartChase);
        if (c.GetComponentInParent<PlayerMovement>())
        {
            setChaseToStart(c);

        }
    }

    public void setChaseToStart(GameObject c)
    {
        
            Debug.Log("Spotted player");
            me.setPlayerTransform(c.transform);
            me.agent.isStopped = false;
            hasSeen = true;
            recentLostSight = false;
            me.agent.gameObject.transform.forward = c.transform.position;
            this.StopAllCoroutines();
      
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Resuming path");
        if (other.GetComponentInParent<PlayerMovement>())
        {
            recentLostSight = true;
            me.agent.isStopped = false;
            StartCoroutine(WaitAlertPeriod());
            StartCoroutine(LostSightTimer());
        }
    }

    IEnumerator LostSightTimer()
    {
        yield return new WaitForSeconds(me.secondForLoseAggro);
        if(!hasSeen)
        {
            me.ResetBehaviour();
        }
    }

    IEnumerator WaitAlertPeriod()
    {
        yield return new WaitForSeconds(me.alertPeriodDuration);
        hasSeen = false;
        recentLostSight = false;
    }
}
