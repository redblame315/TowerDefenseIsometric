using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy), typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    private float baseSpeed = 0;
    private float currentSpeed = 0;
    
    private NavMeshAgent agent;
  

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("ResetSpeed", 0f, 0.5f);
    }

    public void ChangeMoveSpeed(float modifier)
    {      
        agent.speed = currentSpeed * (1f - modifier);
    }

    public void SetTarget(Transform target)
    {
        agent.SetDestination(target.position);
    }

    public void SetBaseSpeed(float value)
    {
        baseSpeed = currentSpeed = value;
        agent.speed = baseSpeed;
    }

    void ResetSpeed()
    {
        if (currentSpeed == 0 && baseSpeed == 0) return;

        currentSpeed = baseSpeed;
        agent.speed = currentSpeed;
    }
}
