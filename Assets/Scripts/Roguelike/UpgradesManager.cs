using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Roguelike
{
    public class UpgradesManager : MonoBehaviour
    {
        [SerializeField] private List<UpgradeButton> upgradeButtons;
        [SerializeField] private Transform upgradePanel; // Painel onde as opções de melhorias são exibidas
        [SerializeField] private List<AttributeUpgrade> upgrades;
        [SerializeField] Image background;
        private int _currentPlayerIndex;

        public void ShowUpgrades()
        {
            GameManager gm = GameManager.Instance;
            var players = gm.Players.ToList();
            if (_currentPlayerIndex >= players.Count)
            {
                Time.timeScale = 1;
                upgradePanel.gameObject.SetActive(false);
                _currentPlayerIndex = 0;
            } else
            {
                Time.timeScale = 0;
                background.color = players[_currentPlayerIndex].PlayerColor;
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
                    upgradeButtons[i].Setup(selectedUpgrades[i], players[_currentPlayerIndex], () =>
                    {
                        _currentPlayerIndex++;
                        ShowUpgrades();
                    });
                }

                upgradePanel.gameObject.SetActive(true);
            }
        }
    }
}
