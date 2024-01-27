using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class ItemEffects:MonoBehaviour
{
    PlayerMovement movement;
    PlayerCam cam;
    Rigidbody playerRb;
 
    private bool isSpinachEffect = false;
    private float spinachForce = 500f;

    Prodotti products;

    private void Start()
    {
        movement= GetComponentInChildren<PlayerMovement>();
        cam = GetComponentInChildren<PlayerCam>();
        
        playerRb = GetComponent<Rigidbody>();
    }
    public void ApplyItemEffect(InventoryItems inventory)
    {
        Products product = inventory.special;

        switch (product)
        {
            case Products.banana:
                inventory.special = Products.noSpecial;
                inventory.UseSpecialItem();
                StartCoroutine(BananaEffect());
                break;

            case Products.beans:
                StartCoroutine(BeansEffect());
                break;

            case Products.spinach:
                StartCoroutine(SpinachEffect());
                break;

            case Products.nutella:
                StartCoroutine(NutellaEffect());
                break;

            case Products.onion:
                StartCoroutine(OnionEffect());
                break;

            case Products.wine:
                StartCoroutine(WineEffect());
                break;


        }
    }

  
    public IEnumerator BananaEffect()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFXs/Interagibili/Banana");

        float oldvalue = cam.sensX;
        cam.sensX *= -1f;

        yield return new WaitForSeconds(2f);

        cam.sensX = oldvalue;

        //float time = 0f;

        //while (time < 2f)
        //{
        //    time += Time.deltaTime;
        //    yield return null;
        //}
        //
    }

    public IEnumerator BeansEffect()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFXs/Interagibili/Fagioli");
        movement.moveSpeed *= 2;
       
        yield return new WaitForSeconds(5f);

        movement.moveSpeed /= 2;
        
    }

    public IEnumerator SpinachEffect()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFXs/Interagibili/Spinaci");
        isSpinachEffect = true;
      
        yield return new WaitForSeconds(20f);

        isSpinachEffect = false;

    }

    public IEnumerator NutellaEffect()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFXs/Interagibili/Nutella");
        movement.moveSpeed /= 3;

        yield return new WaitForSeconds(10f);

        movement.moveSpeed *= 3f;

    }

    public IEnumerator OnionEffect()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFXs/Interagibili/Cipolle");
        float originalSpeed = movement.moveSpeed;
        movement.moveSpeed = 0f;

        yield return new WaitForSeconds(5f);

        movement.moveSpeed = originalSpeed;

    }

    public IEnumerator WineEffect()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFXs/Interagibili/Vino");
        Quaternion originalRotation = cam.gameObject.transform.rotation;

        cam.gameObject.transform.Rotate(0f, 2f * Time.deltaTime, 0f);

        yield return new WaitForSeconds(5f);

        cam.gameObject.transform.rotation = originalRotation;

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (isSpinachEffect)
        {
            Debug.Log("Collided with explosive force");
            Vector3 collisionForce = collision.impulse / Time.fixedDeltaTime;
            playerRb.AddExplosionForce(collisionForce.magnitude * spinachForce, collision.contacts[0].point, 5);

        }
    }

}
