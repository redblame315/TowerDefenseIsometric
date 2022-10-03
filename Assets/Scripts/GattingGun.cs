using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GattingGun : Turret
{
    [SerializeField]
    private GameObject bulletPrefab;

    protected override void Shoot()
    {
        base.Shoot();

        if (bulletPrefab == null)
        {
            Debug.LogError("Bala não carregada no prefab");
            return;
        }

        GameObject newBullet = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Projectile projectile = newBullet.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.Seek(target);
        }
    }
}
