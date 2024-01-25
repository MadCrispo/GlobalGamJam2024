using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prodotti : MonoBehaviour
{
    public int number;
    public bool cheese;
    public bool bread;
    
    


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
                    DisplayIcons();
                }
                InventoryItems.cheese++;
                Destroy(gameObject);
            }
            else
            {
                DisplayIcons();
                Destroy(gameObject);
            }
            
        }
       

    }
    void DisplayIcons()
    {
        InventoryItems.newIcon = number;
        InventoryItems.iconUpdate = true;
    }
}
