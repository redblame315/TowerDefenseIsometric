using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret : MonoBehaviour
{    
    [Header("Turret Stats")]
    [SerializeField]
    [Range(1f, 100f)]
    protected float range = 15f;
    [SerializeField]
    [Range(1f, 100f)]
    protected float turnSpeed = 10f;
    [SerializeField]
    [Range(0f, 10f)]
    protected float fireRate = 1f;

    [Header("Turret Components")]
    [SerializeField]
    protected Transform partToRotate;
    [SerializeField]
    protected Transform firePoint;

    protected Transform tf;
    protected Transform target;
    protected Enemy targetEnemy;

    private float fireTimer;
    private float nextFire;


    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        tf = GetComponent<Transform>();
        fireTimer = nextFire = 0f;
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(tf.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    protected virtual void Update()
    {
        if (target == null) return;
        fireTimer += Time.deltaTime;
        LockOnTarget();

        if (CanShoot())
        {
            Shoot();
        }
    }    

    private void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private bool CanShoot()
    {
        return fireTimer >= nextFire;
    }

    //Will be handled by the children.
    protected virtual void Shoot()
    {        
        Debug.Log("Shot something at enemy");
        nextFire = fireTimer + fireRate;


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
