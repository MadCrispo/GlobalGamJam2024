using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItems : MonoBehaviour
{
    public Image [] empitySlots;
    public Image  SpecialSlot;
    public Sprite empityIcon;
    public Sprite[] icons;
    public static List<int> allProducts = new List<int>();

    public static InventoryItems instance;
    public Products special { get; set; }
    private void Awake()
    {
        if (instance == null)
            instance = this;

        for (int x = 0; x < 20; x++)
        {
            allProducts.Add(0);
        }
    }
    public void AddSpecialIcon(Products product)
    {
        if (SpecialSlot.sprite == empityIcon)
        {
            SpecialSlot.sprite = icons[(int)product];
            special = product;
            return;
        }
    }

    public void AddIcon(Products product)
    {
        for (int i = 0; i < empitySlots.Length; i++)
        {
            if (empitySlots[i].sprite == empityIcon)
            {
                empitySlots[i].sprite = icons[(int)product];
                return;
            }
        }
    }
    public void EmptyIcon(Products product)
    {
        for (int i = 0; i < empitySlots.Length; i++)
        {
            if (empitySlots[i].sprite == icons[(int)product])
            {
                empitySlots[i].sprite = empityIcon;
                return;
            }
        }
    }
    public  void AddItem(Products product)
    {
        allProducts[(int)product]++;
        instance.AddIcon(product);
    }

    public  void UseItem(Products product)
    {
        if(allProducts[(int)product]>0)
            allProducts[(int)product]--;

        if (allProducts[(int)product] == 0)
            instance.EmptyIcon(product);
    }
    public void UseSpecialItem()
    {
        SpecialSlot.sprite = empityIcon;
    }
}
public enum Products
{
   noSpecial=0, bread=1, cheese=2,beans=3,banana=4,spinach=5,nutella=6,wine=7,panettone=9
}