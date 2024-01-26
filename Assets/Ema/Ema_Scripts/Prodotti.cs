using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prodotti : MonoBehaviour
{
    public int number;
    public bool cheese;
    public bool bread;


    public Products product;

    void Start()
    {
        
    }

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (bread == true)
            {

                if (InventoryItems.bread == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.bread++;
                Destroy(gameObject);
            }
            else if (cheese == true)
            {
                if (InventoryItems.cheese == 0)
                {
                }
                InventoryItems.cheese++;
                Destroy(gameObject);
            }
            else
            {
                DisplayIcons();
                Destroy(gameObject);
            }
            DisplayIcons();
            
        }
       

    }
    void DisplayIcons()
    {
        InventoryItems.newIcon = number;
        InventoryItems.iconUpdate = true;
    }
    
}
