using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player _instance;
    public static Player Instance { get { return _instance; } }


    [SerializeField]
    private int startingLives = 3;
    [SerializeField]
    private int startingHP = 10;
    [SerializeField]
    private int startingMoney = 300;


    private int currentLives;
    private int currentMoney;
    private int currentHP;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Reset();
    }

    public int GetPlayerCurrentMoney()
    {
        return currentMoney;
    }

    public int GetPlayerCurrentLives()
    {
        return currentLives;
    }

    public void AddCurrency(int value)
    {
        currentMoney += value;
    }

    public void SpendMoney(int value)
    {
        currentMoney -= value;
    }


    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            DecreaseLife();
        }
    }

    void DecreaseLife()
    {
        if (currentLives >= 0)
        {
            currentLives--;
            currentHP = 100;
        }
        else
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Kill Player");
    }

    public void Reset()
    {
        currentMoney = startingMoney;
        currentLives = startingLives;
        currentHP = startingHP;
    }
}
