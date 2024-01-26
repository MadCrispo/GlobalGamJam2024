using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItems : MonoBehaviour
{
    public Image [] empitySlots;
    public Sprite empityIcon;
    public static int newIcon = 0;
    public static bool iconUpdate = false;
    public Sprite[] icons;
    public int max;
    public static int bread = 0;
    public static int cheese= 0;
    public static List<int> allProducts = new List<int>();

    public static InventoryItems instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        max = empitySlots.Length;
        bread = 0;
        cheese = 0;
        for (int x=0;x<20;x++)
        {
            allProducts.Add(0);
        }
    }

    //Update is called once per frame
    void Update()
    {
        if (iconUpdate == true)
        {
            for (int i = 0; i < max; i++)
            {
                if (empitySlots[i].sprite == empityIcon)
                {
                    max = i;
                    empitySlots[i].sprite = icons[newIcon];

                }
            }
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(1);
        iconUpdate = false;
        max = empitySlots.Length;
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
    public static void AddItem(Products product)
    {
        allProducts[(int)product]++;
        instance.AddIcon(product);
    }

    public static void UseItem(Products product)
    {
        if(allProducts[(int)product]>0)
            allProducts[(int)product]--;

        if (allProducts[(int)product] == 0)
            instance.EmptyIcon(product);
    }
}
public enum Products
{
    bread=1, cheese=2
}