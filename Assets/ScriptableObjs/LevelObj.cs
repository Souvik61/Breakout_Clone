using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Object")]
public class LevelObj : ScriptableObject
{
    [SerializeField]
    private GameObject level1Prefab;
    [SerializeField]
    private GameObject level2Prefab;
    [SerializeField]
    private GameObject level3Prefab;
    [SerializeField]
    private GameObject level4Prefab;
    [SerializeField]
    private GameObject level5Prefab;
    [SerializeField]
    private GameObject level6Prefab;

    private int toStartLevelId = 1;
    private Dictionary<int, GameObject> levelPairs=new Dictionary<int, GameObject>();

    // This function is called when the object becomes enabled and active
    private void OnEnable()
    {
        levelPairs.Add(1, level1Prefab);
        levelPairs.Add(2, level2Prefab);
        levelPairs.Add(3, level3Prefab);
        levelPairs.Add(4, level4Prefab);
        levelPairs.Add(5, level5Prefab);
        levelPairs.Add(6, level6Prefab);
    }


    public GameObject GetLevelPrefabWithID(int id)
    {
        return levelPairs[id];
    }

    public void SetToStartLevelID(int levelID)
    {
        toStartLevelId = levelID;
    }

    public int GetToStartLevelID()
    {
        return toStartLevelId;
    }
}
