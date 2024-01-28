using System.Collections.Generic;
using UnityEngine;

public class ShelfCollision : MonoBehaviour
{
    public int numItem = 1;
    public Products product = Products.banana;

    // The particle system reference
    public ParticleSystem collisionParticles;
    public List<GameObject> itemstoremove;

    private void Start()
    {
        // Is the particle system assigned?
        if (collisionParticles == null)
        {
            Debug.LogError("Particle system not assigned. Please assign it in the Unity Editor.");
        }
        else
        {
            // At the start the particle system is off
            collisionParticles.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!Gamemanager.CanBuy)
            return;

        PlayerWallet wallet = collision.gameObject.GetComponentInParent<PlayerWallet>();
        Debug.Log("Owner collided with a Cart!");

        if (collisionParticles != null)
        {
            // The first Spoint of contact
            ContactPoint contactPoint = collision.GetContact(0);

            // Particles starts in the collision point
            collisionParticles.transform.position = contactPoint.point;

            // Particles start
            collisionParticles.Play();
        }
        if (product == Products.noSpecial)
            return;

        if (numItem > 0)
        {
            numItem--;
            if (wallet.IsNextProduct(product))
            {
                if (wallet.id == PlayerWallet.listaspesa.Count)
                {
                    Gamemanager.instance.WinGame.Invoke();
                }
            }

            wallet?.BuyStuff(product);
            wallet.GetComponent<ItemEffects>().ApplyItemEffect(wallet.inventory,product);
            //if (product != Products.noSpecial)
            //   wallet.inventory.AddSpecialIcon(product);
            //else
            //    wallet.inventory.AddItem(product);
            if (!wallet.CanIBuyIt(product))
                Gamemanager.instance.LoseGame.Invoke();


            wallet.AddToCart(product);
            foreach (GameObject item in itemstoremove)
            {
                if (item != null)
                    Destroy(item);
            }
        }
    }
}