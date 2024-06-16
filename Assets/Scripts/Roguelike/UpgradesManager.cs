using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour
{
    [SerializeField] private List<UpgradeButton> upgradeButtons;
    [SerializeField] private Transform upgradePanel; // Painel onde as opções de melhorias são exibidas
    [SerializeField] private List<AttributeUpgrade> upgrades;
    private int currentPlayerIndex;

    public void ShowUpgrades()
    {
        GameManager gm = GameManager.Instance;
        var players = gm.Players.ToList();
        if (currentPlayerIndex >= players.Count)
        {
            upgradePanel.gameObject.SetActive(false);
            currentPlayerIndex = 0;
        } else
        {
            List<AttributeUpgrade> selectedUpgrades = new List<AttributeUpgrade>();
            while (selectedUpgrades.Count < upgradeButtons.Count)
            {
                AttributeUpgrade randomUpgrade = upgrades[UnityEngine.Random.Range(0, upgrades.Count)];
                if (!selectedUpgrades.Contains(randomUpgrade))
                {
                    selectedUpgrades.Add(randomUpgrade);
                }
            }

            for (int i = 0; i < upgradeButtons.Count; i++)
            {
                upgradeButtons[i].Setup(upgrades[i], players[currentPlayerIndex], () =>
                {
                    currentPlayerIndex++;
                    ShowUpgrades();
                });
            }

            upgradePanel.gameObject.SetActive(true);
        }
    }
}
