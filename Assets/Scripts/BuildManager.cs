using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private static BuildManager _instance;
    public static BuildManager Instance { get { return _instance; } }

    [SerializeField]
    private GameObject buildParticleEffect;

    [SerializeField]
    private GameObject sellParticleEffect;

    [SerializeField]
    private GameObject upgradeParticle;


    [SerializeField]
    private NodeUI nodeUI;

    private BuildBlueprint turretToBuild;
    private Node selectedNode;

    public bool HasTurretToBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return Player.Instance.GetPlayerCurrentMoney() >= turretToBuild.cost; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
    }


    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SetTurretToBuild(BuildBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public BuildBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public GameObject GetParticle(string particlename)
    {
        GameObject particle = new GameObject();
        switch (particlename)
        {
            case "Build":
                particle = buildParticleEffect;
                break;
            case "Sell":
                particle = sellParticleEffect;
                break;
            case "Upgrade":
                particle = upgradeParticle;
                break;             
        }
        return particle;
    }
}
