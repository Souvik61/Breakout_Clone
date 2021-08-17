using System.Collections;
using System.Collections.Generic;
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

    // This function is called when the script is started
    private void Awake()
    {

    }



}
