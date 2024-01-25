using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 15f;
    
    //public float rotacionVelocidad = 100f;
    public float horizontalInput;
    public float forwardlInput;


    private float powerStrenght = 15f;

    public bool hasPowerUp = false;
    public GameObject powerUpIndicatore;


    void Start()
    {
       
    }

    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        forwardlInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed*Time.deltaTime*forwardlInput);
        transform.Translate(Vector3.right * speed * Time.deltaTime*horizontalInput);

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            powerUpIndicatore.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());
            
        }
    }

    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(5);
        hasPowerUp = false;
        powerUpIndicatore.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp) 
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPlayer*powerStrenght,ForceMode.Impulse);
            Debug.Log("Collido con il mio nemico"+collision.gameObject.name);
        }
    }

}

