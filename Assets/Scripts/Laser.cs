using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : Turret
{
    [Header("Laser Stats")]
    [SerializeField]
    [Range(0.0f, 10f)]
    private float damageOverTime = 1f;
    [SerializeField]
    [Range(0.1f, 1f)]
    private float slowAmmount = 0.5f;

    [Header("Laser Components")]    
    [SerializeField]
    private LineRenderer lineRenderer;
    [SerializeField]
    private Light impactLight;
    [SerializeField]
    private ParticleSystem impactEffect;


    protected override void Update()
    {
        if (target == null)
        {
            ToggleEffects(false);
        }
        base.Update();
    }

    protected override void Shoot()
    {
        base.Shoot();
        LaserShot();
    }   

    void LaserShot()
    {
        targetEnemy.TakeDamage(Mathf.CeilToInt(damageOverTime * Time.deltaTime));
        targetEnemy.Slow(slowAmmount);

        if (!lineRenderer.enabled)
        {
            ToggleEffects(true);
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;
        impactEffect.transform.position = target.position + dir.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }


    void ToggleEffects(bool value)
    {
        if (value)
        {
            impactEffect.Play();
        }
        else
        {
            impactEffect.Stop();
        }

        lineRenderer.enabled = value;
        impactLight.enabled = value;
    }
}
