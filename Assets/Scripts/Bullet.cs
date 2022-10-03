using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    protected override void HitTarget()
    {
        base.HitTarget();
        Damage(_target);
    }
}
