using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Projectile
{
    [Header("Missile Stats")]
    [SerializeField]
    [Range(1f, 100f)]
    private float explosionRadius = 10f;

    protected override void HitTarget()
    {
        base.HitTarget();
        Explode();
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(tf.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
