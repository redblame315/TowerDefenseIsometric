using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected Transform _target;

    [Header("Projectile Stats")]
    [SerializeField]
    [Range(1f, 100f)]
    protected float speed = 70f;

    [SerializeField]
    [Range(1f, 100f)]
    protected int damage = 50;

    [Header("Projectile Components")]
    [SerializeField]
    protected GameObject impactParticle;

    protected Transform tf;

    private void Start()
    {
        tf = GetComponent<Transform>();
    }

    public void Seek(Transform target)
    {
        _target = target;
    }

    void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - tf.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        tf.Translate(dir.normalized * distanceThisFrame, Space.World);
        tf.LookAt(_target);
    }

    protected virtual void HitTarget()
    {
        if (impactParticle != null)
        { 
            GameObject particleInstance = (GameObject)Instantiate(impactParticle, tf.position, tf.rotation);
            Destroy(particleInstance, 5f);
        }

        Destroy(gameObject);
    }

    protected void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }
    
}
