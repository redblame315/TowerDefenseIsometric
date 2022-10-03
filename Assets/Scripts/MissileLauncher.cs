using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : Turret
{
    [SerializeField]
    private GameObject missilePrefab;

    protected override void Shoot()
    {
        base.Shoot();

        if (missilePrefab == null)
        {
            Debug.LogError("Bala não carregada no prefab");
            return;
        }

        GameObject newBullet = (GameObject)Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
        Projectile projectile = newBullet.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.Seek(target);
        }
    }
}
