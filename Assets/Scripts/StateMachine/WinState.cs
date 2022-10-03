using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinState : State
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private TextMeshProUGUI waveStat;
    [SerializeField]
    private TextMeshProUGUI enemiesKilledStat;

    public override void Enter()
    {
        canvas.enabled = true;
    }

    public override void Exit()
    {
        canvas.enabled = false;
        Spawner.Instance.Reset();
        Player.Instance.Reset();
    }

    public override string GetStateName()
    {
        return "Win";
    }

    public override void Tick()
    {
        
    }

    private void SetStats()
    {
        waveStat.text = "Waves Survived:\n" + Spawner.Instance.GetWaveCount().ToString();
        enemiesKilledStat.text = "Enemies Killed:\n" + Spawner.Instance.GetWaveCount().ToString();
    }

    public void Retry()
    {        
        GameManager.Instance.SwitchStates("Game");
    }

    public void MainMenu()
    {
        GameManager.Instance.SwitchStates("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
