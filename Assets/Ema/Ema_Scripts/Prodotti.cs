using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prodotti : MonoBehaviour
{
    public int number;
    
    
    
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
            InventoryItems.newIcon = number;
            InventoryItems.iconUpdate = true;
            Destroy(gameObject);
            Debug.Log("Tocco il prodotto");
        }
    }
}
