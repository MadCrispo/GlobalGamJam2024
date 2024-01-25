using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class AI_Controller : MonoBehaviour
{
    public List<Transform> shelfPositions;

    public List<Civilian> aiCivilianList;

    public int changeTimer = 30;

    IEnumerator GenerateNewDestination()
    {
        SetDestinations();

        yield return new WaitForSeconds(changeTimer);

        StartCoroutine(GenerateNewDestination());
    }

    private void Start()
    {
        StartCoroutine(GenerateNewDestination());

    }

    public void SetDestinations()
    {
        List<Transform> avaiablePositions = shelfPositions;

        foreach (Civilian c in aiCivilianList)
        {
            int sorted = 0;
            sorted = Random.Range(0, avaiablePositions.Count);
            c.newDestination = avaiablePositions[sorted];
            avaiablePositions.RemoveAt(sorted);
            Debug.Log(avaiablePositions.Count);

        }
    }

}
