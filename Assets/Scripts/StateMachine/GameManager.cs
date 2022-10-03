using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {

    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;


    public State[] states;
    public State GetCurrentState { get { return currentState; } }

    private State currentState;
    private State previousState;

    private Dictionary<string, State> _stateDict = new Dictionary<string, State>();

    void OnEnable()
    {

        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }

        _stateDict.Clear();

        for (int i = 0; i < states.Length; i++)
        {
            _stateDict.Add(states[i].GetStateName(), states[i]);
        }

        currentState = states[0];
        currentState.Enter();
    }

    void Update()
    {
        currentState.Tick();
    }

    public State FindState(string stateName)
    {
        State state;

        if (!_stateDict.TryGetValue(stateName, out state))
        {
            Debug.Log("Estado não encontrado");
            return null;
        }

        return state;
    }

    public void SwitchStates(string stateName)
    {
        State newState = FindState(stateName);

        if (currentState != null)
        {
            currentState.Exit();
        }

        previousState = currentState;
        currentState = newState;
        currentState.Enter();
    }
}
