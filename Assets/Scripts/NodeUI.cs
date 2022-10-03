using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    [SerializeField]
    private GameObject ui;

    [SerializeField]
    private Text upgradeCostText;
    [SerializeField]
    private Button upgradeButton;

    [SerializeField]
    private Text sellAmmountText;

    private Node _target;

    public void SetTarget(Node target)
    {
        _target = target;
        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCostText.text = "Upgrade" +
                "\n$" + target.GetUpgradeCostToSting();
            upgradeButton.interactable = true;            
        }
        else
        {
            upgradeCostText.text = "Already upgraded";
            upgradeButton.interactable = false;
        }

        sellAmmountText.text = "Sell" +
            "\n$" + target.GetSellValueToString();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        _target.UpgradeTurret();
        BuildManager.Instance.DeselectNode();
    }

    public void Sell()
    {
        _target.SellTurret();
        BuildManager.Instance.DeselectNode();
    }
}
