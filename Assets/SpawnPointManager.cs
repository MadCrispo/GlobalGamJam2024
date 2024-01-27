
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnPointManager : MonoBehaviour
{
    public static SpawnPointManager instance;
    static bool[] occupied= new bool[2];
    PlayerInputManager spawner;
    public List<Camera> allcams= new List<Camera>();    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        spawner = FindAnyObjectByType<PlayerInputManager>();

    }
    public void Spawner_onPlayerJoined(PlayerInput obj)
    {
        Debug.Log("go");
        Gamemanager.CanBuy = false;
        for (int x = 0; x < occupied.Length; x++)
        {
            if (!occupied[x])
            {
                obj.transform.position = transform.GetChild(x).position;
                //obj.transform.GetChild(1).position = transform.GetChild(x).position;
                //obj.transform.gameObject.SetActive(true);
                occupied[x] = true;
                StartCoroutine(StayThere(obj.transform.GetChild(1).gameObject, obj.camera));
                return;
            }
        }
    }

    private IEnumerator StayThere(GameObject obj,Camera cam)
    {
        yield return new WaitForSeconds(1f);
        allcams.Add(cam);
        obj.transform.localPosition = Vector3.zero;
        int i = 0;
        if (allcams.Count > 1)
        {
            foreach (Camera c in allcams)
            {
                c.rect = new Rect(0, i * 0.5f, 1, 0.5f);
                i++;
            }
        }
        Gamemanager.CanBuy = true;
    }

}
