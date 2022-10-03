using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private QuestData questData;

    private int winByEnemiesKilled = int.MaxValue;
    private float winByTimeSurvived = float.MaxValue;
    private int winByWavesSurvived = int.MaxValue;

    private float timer = 0f;

    public void SetQuestData(QuestData data)
    {
        questData = data;
        SetWinConditions();        
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    public void CheckWinConditions()
    {
        switch (questData.questType)
        {
            case QuestData.QuestType.DESTROY_ENEMIES:
                int killCount = Spawner.Instance.GetKillCount();
                if (killCount >= winByEnemiesKilled)
                {
                    WinTheGame();
                }
                break;
            case QuestData.QuestType.SURIVIVE_WAVE:
                int wavesSurvived = Spawner.Instance.GetWaveCount();
                if (wavesSurvived >= winByWavesSurvived)
                {
                    WinTheGame();
                }
                break;
            case QuestData.QuestType.SURVIVE_TIME:
                if (timer >= (questData.timeToSurviveInMinutes * 60) )
                {
                    WinTheGame();
                }
                break;
        }
    }

    void SetWinConditions()
    {
        switch (questData.questType)
        {
            case QuestData.QuestType.DESTROY_ENEMIES:
                winByEnemiesKilled = questData.ammountOfEnemiesToDestroy;
                break;
            case QuestData.QuestType.SURIVIVE_WAVE:
                winByWavesSurvived = questData.wavesToSurvive;
                break;
            case QuestData.QuestType.SURVIVE_TIME:
                winByTimeSurvived = questData.timeToSurviveInMinutes;
                break;
        }

        GameManager.Instance.SwitchStates("Game");
    }

    private void WinTheGame()
    {
        GameManager.Instance.SwitchStates("Win");
    }
}
