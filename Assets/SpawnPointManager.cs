
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnPointManager : MonoBehaviour
{
    public static SpawnPointManager instance;
    static bool[] occupied= new bool[4];
    PlayerInputManager spawner;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        spawner = FindAnyObjectByType<PlayerInputManager>();

    }
    public void Spawner_onPlayerJoined(PlayerInput obj)
    {
        Debug.Log("go");
        for (int x = 0; x < 4; x++)
        {
            if (!occupied[x])
            {
                obj.transform.position = transform.GetChild(x).position;
                //obj.transform.GetChild(1).position = transform.GetChild(x).position;
                //obj.transform.gameObject.SetActive(true);
                occupied[x] = true;
                StartCoroutine(StayThere(obj.transform.GetChild(1).gameObject));
                return;
            }
            x++;
        }
    }

    private IEnumerator StayThere(GameObject obj)
    {
        yield return new WaitForSeconds(1f);
        obj.transform.localPosition = Vector3.zero;
    }

}
