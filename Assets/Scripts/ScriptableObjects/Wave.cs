using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Wave/Wave List")]
public class Wave : ScriptableObject
{
    public List<Squad> squadList;
    [Range(1f, 100f)]
    public float timeBetweenSquads;
}
