using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Data/Turret/Blueprint")]
public class BuildBlueprint : ScriptableObject
{
    [Header("Default Turret")]
    public GameObject prefab;
    public int cost;


    [Header("Upgraded Turret")]
    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellValue()
    {
        return cost / 2;
    }

} 
