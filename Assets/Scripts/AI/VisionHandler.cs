using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VisionHandler : MonoBehaviour
{
    public Enemy me;
    private bool hasSeen = false;
    private bool recentLostSight = false;

    private void Start()
    {
        me = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (recentLostSight)
        {
            setChaseToStart(other);
        }
        else
        {
            StartCoroutine(WaitForSpot(other));
        }
        
       
    }

    IEnumerator WaitForSpot(Collider c)
    {
        yield return new WaitForSeconds(me.secondToStartChase);
        setChaseToStart(c);
       

    }

    public void setChaseToStart(Collider c)
    {
        if (c.GetComponent<PlayerMovement>())
        {
            me.setPlayerTransform(c.transform);
            hasSeen = true;
            recentLostSight = false;
            this.StopAllCoroutines();
        }
      
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            recentLostSight = true;
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
