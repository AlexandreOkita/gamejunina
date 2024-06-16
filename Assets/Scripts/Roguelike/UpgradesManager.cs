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
    [SerializeField] Image background;
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
            background.color = players[currentPlayerIndex].PlayerColor;
            List<AttributeUpgrade> selectedUpgrades = new List<AttributeUpgrade>();
            while (selectedUpgrades.Count < upgradeButtons.Count)
            {
                System.Random random = new System.Random();
                var rUpgradeIndex = random.Next(0, upgrades.Count);
                AttributeUpgrade randomUpgrade = upgrades[rUpgradeIndex];
                if (!selectedUpgrades.Contains(randomUpgrade))
                {
                    selectedUpgrades.Add(randomUpgrade);
                }
            }

            for (int i = 0; i < upgradeButtons.Count; i++)
            {
                upgradeButtons[i].Setup(selectedUpgrades[i], players[currentPlayerIndex], () =>
                {
                    currentPlayerIndex++;
                    ShowUpgrades();
                });
            }

            upgradePanel.gameObject.SetActive(true);
        }
    }
}
