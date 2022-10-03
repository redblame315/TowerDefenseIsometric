using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Character/Stats")]
public class Stats : ScriptableObject
{
    [Range(1f, 100f)]
    public int startingHealth = 10;

    [Range(1f, 100f)]
    public float baseSpeed = 2f;

    [Range(1f, 100f)]
    public int damage = 1;

    [Range(50f, 500f)]
    public int pointsValue = 50;
}
