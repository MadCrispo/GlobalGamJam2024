using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;

public class AI_Controller : MonoBehaviour
{
    public List<Transform> shelfPositions;

    public List<Civilian> aiCivilianList;

    public List<Enemy> aiEnemyList;

    public int changeTimer = 30;

    IEnumerator GenerateNewDestinationPacific()
    {
        SetShelfDestinations();

        yield return new WaitForSeconds(changeTimer);

        StartCoroutine(GenerateNewDestinationPacific());
    }

    private void Start()
    {
        UpdateCivilianList();
        UpdateEnemyList();
        StartCoroutine(GenerateNewDestinationPacific());

    }

    public void SetShelfDestinations()
    {
        List<Transform> avaiablePositions = new List<Transform>(shelfPositions);

        foreach (Civilian c in aiCivilianList)
        {
            int sorted = 0;
            sorted = Random.Range(0, avaiablePositions.Count);
            c.newDestination = avaiablePositions[sorted];
            avaiablePositions.RemoveAt(sorted);

        }
    }

    public void UpdateCivilianList()
    {
        List<Civilian> currentSceneCivilian = new List<Civilian>();
        currentSceneCivilian.Clear();
        Civilian[] civilianInScene = FindObjectsOfType<Civilian>();
        currentSceneCivilian.AddRange(civilianInScene);
        aiCivilianList.Clear();
        aiCivilianList = currentSceneCivilian;
        
    }

    public void UpdateEnemyList()
    {
        List<Enemy> currentSceneEnemy = new List<Enemy>();
        currentSceneEnemy.Clear();
        Enemy[] enemyInScene = FindObjectsOfType<Enemy>();
        currentSceneEnemy.AddRange(enemyInScene);
        aiEnemyList.Clear();
        aiEnemyList = currentSceneEnemy;

    }

}
