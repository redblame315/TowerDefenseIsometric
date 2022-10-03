using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDifficultyState : State
{
    [SerializeField]
    private Canvas canvas;

    public override void Enter()
    {
        canvas.enabled = true;
    }

    public override void Exit()
    {
        canvas.enabled = false;
    }

    public override string GetStateName()
    {
        return "DifficultySelect";
    }

    public override void Tick()
    {
        
    }
}
