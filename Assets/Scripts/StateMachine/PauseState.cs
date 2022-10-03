using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseState : State
{
    [SerializeField]
    private Canvas pauseCanvas;

    public override void Enter()
    {
        Time.timeScale = 0f;
    }

    public override void Exit()
    {
        Time.timeScale = 1f;
    }

    public override string GetStateName()
    {
        return "Pause";
    }

    public override void Tick()
    {
        
    }

    public void ResumeGame()
    {
        GameManager.Instance.SwitchStates("Game");
    }

    public void ReturnToMainMenu()
    {
        GameManager.Instance.SwitchStates("MainMenu");
    }
}
