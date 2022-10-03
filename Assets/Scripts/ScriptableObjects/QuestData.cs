using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Data/Quest/Quest Data")]
public class QuestData : ScriptableObject
{
    public enum QuestType
    {
        DESTROY_ENEMIES,
        SURVIVE_TIME,
        SURIVIVE_WAVE
    }

    public QuestType questType;

    [Range(10, 100)]
    public int ammountOfEnemiesToDestroy = 1;

    [Range(1f, 5f)]
    public float timeToSurviveInMinutes = 1f;

    [Range(1f, 100f)]
    public int wavesToSurvive = 1;
}
