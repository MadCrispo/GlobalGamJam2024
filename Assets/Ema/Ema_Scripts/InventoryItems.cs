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
    void Start()
    {
        max = empitySlots.Length;

        bread = 0;
        cheese = 0;

    }

    // Update is called once per frame
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
                    //empitySlots[i].transform.gameObject.GetComponent<HintMessage>().ObjectType = newIcon;

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
}
