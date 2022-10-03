using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField]
    private Color hoverColor;
    [SerializeField]
    private Color notEnoughMoneyColor;
    [SerializeField]
    private Color canBeUpgradedColor;
    [SerializeField]
    private Vector3 positionOffset;

    private GameObject currentTurret;
    private BuildBlueprint storedBlueprint;
    public bool isUpgraded = false;

    private Renderer rend;
    private Color originalColor;

	void Start ()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
	}

    public bool CanBuildHere()
    {
        return currentTurret == null ? true : false;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void BuildTurretHere(BuildBlueprint buildBlueprint)
    {
        if (Player.Instance.GetPlayerCurrentMoney() < buildBlueprint.cost)
        {
            Debug.Log("Need more money");
            return;
        }

        Player.Instance.SpendMoney(buildBlueprint.cost);

        

        GameObject newTurret = (GameObject)Instantiate(buildBlueprint.prefab, GetBuildPosition(), Quaternion.identity);
        currentTurret = newTurret;


        //TODO:Instantiate some particle effects
        GameObject newParticle = (GameObject)Instantiate(BuildManager.Instance.GetParticle("Build"), GetBuildPosition(), Quaternion.identity);
        Destroy(newParticle, 5f);

        storedBlueprint = buildBlueprint;
    }

    public void UpgradeTurret()
    {
        if (Player.Instance.GetPlayerCurrentMoney() < storedBlueprint.upgradeCost)
        {
            Debug.Log("Need more money");
            return;
        }

        Player.Instance.SpendMoney(storedBlueprint.upgradeCost);

        Destroy(currentTurret);

        GameObject newTurret = (GameObject)Instantiate(storedBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        currentTurret = newTurret;

        isUpgraded = true;

        //TODO:Instantiate some particle effects
    }

    public void SellTurret()
    {
        Player.Instance.AddCurrency(storedBlueprint.GetSellValue());
        //Instantiate some particles;

        Destroy(currentTurret);
        storedBlueprint = null;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (CanBuildHere() && !isUpgraded)
        {
            rend.material.color = hoverColor;
        }
        else if (!CanBuildHere() && !isUpgraded)
        {
            rend.material.color = canBeUpgradedColor;
        }
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!CanBuildHere())
        {
            BuildManager.Instance.SelectNode(this);
            return;
        }

        if (!BuildManager.Instance.HasTurretToBuild)
        {
            return;
        }

        BuildTurretHere(BuildManager.Instance.GetTurretToBuild());

    }

    private void OnMouseExit()
    {
        rend.material.color = originalColor;
    }

    public string GetBuildCostToString()
    {
        return storedBlueprint.cost.ToString();
    }

    public string GetUpgradeCostToSting()
    {
        return storedBlueprint.upgradeCost.ToString();
    }

    public string GetSellValueToString()
    {
        return storedBlueprint.GetSellValue().ToString();
    }
}
