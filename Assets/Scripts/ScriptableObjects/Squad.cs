using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/Wave/Squad")]
public class Squad : ScriptableObject
{
    [Header("Squad Components")]
    public GameObject enemyPrefab;

    [Header("Squads Data")]
    [Range(1f, 100f)]
    public float timeBetweenSpawns = 1f;
    [Range(1f, 100f)]
    public int enemiesToSpawn = 4;
}
