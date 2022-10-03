using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : State
{
    [SerializeField]
    private Canvas menuCanvas;

    [SerializeField]
    private Canvas settingsCanvas;    

    public override void Enter()
    {
        if (!EnsureComponents())
        {
            Debug.LogError("Ta faltando alguns componentes");
        }

        menuCanvas.enabled = true;
        settingsCanvas.enabled = false;
    }

    private bool EnsureComponents()
    {
        return (menuCanvas == null || settingsCanvas == null) ? false : true;
    }

    public override void Exit()
    {
        menuCanvas.enabled = false;
        settingsCanvas.enabled = false;
    }

    public override string GetStateName()
    {
        return "MainMenu";
    }

    public override void Tick()
    {
        
    }

    public void StartGame()
    {
        GameManager.Instance.SwitchStates("DifficultySelect");
    }

    public void OpenSettingsMenu()
    {
        menuCanvas.enabled = false;
        settingsCanvas.enabled = true;
    }

    public void CloseSettingsMenu()
    {
        menuCanvas.enabled = true;
        settingsCanvas.enabled = false;
    }
}
