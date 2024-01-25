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
    void Start()
    {
        max = empitySlots.Length;
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
