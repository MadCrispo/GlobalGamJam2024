using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffects:MonoBehaviour
{
    PlayerMovement movement;
    PlayerCam cam;

    private void Start()
    {
        movement= GetComponentInChildren<PlayerMovement>();
        cam = GetComponentInChildren<PlayerCam>();
    }
    public void ApplyItemEffect()
    {
        Products product = InventoryItems.instance.special;

        switch (product)
        {
            case Products.banana:
                InventoryItems.instance.special = Products.noSpecial;
                InventoryItems.instance.UseSpecialItem();
                StartCoroutine(BananaEffect());
                break;
        }
    }

    public IEnumerator BananaEffect()
    {
        float oldvalue = cam.sensX;
        float time = 0f;
        cam.sensX *= -1f;
        while (time < 1f)
        {
            time += Time.deltaTime;
            yield return null;
        }
        cam.sensX = oldvalue;
    }
}
