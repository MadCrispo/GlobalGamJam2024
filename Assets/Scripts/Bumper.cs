using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float NoBumptime = 5f;
    bool routine;

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
            Vector3 collisionForce = collision.impulse / Time.fixedDeltaTime;
            StartCoroutine(WaitForRebump());
            //Debug.Log("collision "+ collisionForce.magnitude);
            collision.rigidbody.AddExplosionForce(collisionForce.magnitude, collision.contacts[0].point, 5);
        }
    }

}
