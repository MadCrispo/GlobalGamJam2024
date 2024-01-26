using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float NoBumptime = 5f;
    
    public float bounceforce=100;
    bool  routine;

    public IEnumerator WaitForRebump()
    {
        routine = true;
        yield return new WaitForSeconds(NoBumptime);
        routine = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!routine)
        {
            StartCoroutine(WaitForRebump());
            Debug.Log("collision");
            collision.rigidbody.AddExplosionForce(bounceforce, collision.contacts[0].point, 5);
        }
    }

}
