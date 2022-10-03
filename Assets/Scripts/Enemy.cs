using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private Stats enemyStats;
    [SerializeField]
    private GameObject deathParticle;
    
    private int currentHealth;

    private EnemyMovement movement;

	// Use this for initialization
	void Start ()
    {
        currentHealth = enemyStats.startingHealth;
        movement = GetComponent<EnemyMovement>();
        movement.SetBaseSpeed(enemyStats.baseSpeed);
	}	

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Slow(float ammount)
    {
        movement.ChangeMoveSpeed(ammount);
    }

    public float GetBaseSpeed()
    {
        return enemyStats.baseSpeed;
    }

    void Die()
    {
        if (deathParticle != null)
        {
            GameObject newParticle = (GameObject)Instantiate(deathParticle, transform.position, transform.rotation);
            Destroy(newParticle, 5f);
        }

        Spawner.Instance.OnEnemyDeath();
        Player.Instance.AddCurrency(enemyStats.pointsValue);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
