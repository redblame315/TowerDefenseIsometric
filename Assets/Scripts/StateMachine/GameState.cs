using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameState : State
{
    [Header("UI Parts")]
    [SerializeField]
    private Canvas gameCanvas;
    [SerializeField]
    private TextMeshProUGUI moneyText;
    [SerializeField]
    private TextMeshProUGUI livesText;


    [Header("Components")]
    [SerializeField]
    private QuestManager questManager;

    public override void Enter()
    {
        Spawner.Instance.StartSpawn();
        gameCanvas.enabled = true;
        InvokeRepeating("Check", 5f, 0.5f);
    }

    public override void Exit()
    {
        gameCanvas.enabled = false;
    }

    public override string GetStateName()
    {
        return "Game";
    }

    public override void Tick()
    {        
        moneyText.text = "Money: $" + Player.Instance.GetPlayerCurrentMoney().ToString();
        livesText.text = "Lives: " + Player.Instance.GetPlayerCurrentLives().ToString();        
    }

    void PauseGame()
    {
        GameManager.Instance.SwitchStates("Pause");
    }

    void Check()
    {
        questManager.CheckWinConditions();
    }
}
