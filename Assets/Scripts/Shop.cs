using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private BuildBlueprint gattlingGun;
    [SerializeField]
    private BuildBlueprint missileLauncher;
    [SerializeField]
    private BuildBlueprint laserTurret;
    [SerializeField]
    private BuildBlueprint canonTurret;

    public void BuyGattlingGun()
    {
        BuildManager.Instance.SetTurretToBuild(gattlingGun);
    }

    public void BuyMissileLauncher()
    {
        BuildManager.Instance.SetTurretToBuild(missileLauncher);
    }

    public void BuyLaserTurret()
    {
        BuildManager.Instance.SetTurretToBuild(laserTurret);
    }

    public void BuyCanonTurret()
    {
        BuildManager.Instance.SetTurretToBuild(canonTurret);
    }
}
