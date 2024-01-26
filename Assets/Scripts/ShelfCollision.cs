using UnityEngine;

public class ShelfCollision : MonoBehaviour
{
    // The cart TAG
    private const string CartTag = "Cart";

    public int numItem=1;
    public Products product=Products.bread;
    // The particle system reference
    public ParticleSystem collisionParticles;

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
        // Check if the collided object has the specified tag
        //if (collision.gameObject.CompareTag(CartTag))
        //{
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


            if (numItem > 0 && PlayerWallet.instance.CanIBuyIt(product))
            {
                numItem--;
                PlayerWallet.instance.BuyStuff(product);
                InventoryItems.AddItem(product);
            }
        //}
    }
}