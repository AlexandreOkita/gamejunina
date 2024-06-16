using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour
{
    [SerializeField] private List<UpgradeButton> upgradeButtons;
    [SerializeField] private Transform upgradePanel; // Painel onde as opções de melhorias são exibidas
    [SerializeField] private List<AttributeUpgrade> upgrades;

    public void ShowUpgrades()
    {
        List<AttributeUpgrade> selectedUpgrades = new List<AttributeUpgrade>();
        while (selectedUpgrades.Count < upgradeButtons.Count)
        {
            AttributeUpgrade randomUpgrade = upgrades[Random.Range(0, upgrades.Count)];
            if (!selectedUpgrades.Contains(randomUpgrade))
            {
                selectedUpgrades.Add(randomUpgrade);
            }
        }

        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].Setup(upgrades[i]);
        }

        upgradePanel.gameObject.SetActive(true);
    }
}
