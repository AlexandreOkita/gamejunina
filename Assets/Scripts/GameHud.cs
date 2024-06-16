using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameHud : MonoBehaviour
    {
        [SerializeField] List<HealthHud> _healthHuds;

        public void ActivateHealthForPlayer(PlayerController playerController)
        {
            HealthHud healthHud = _healthHuds.First(hud => !hud.gameObject.activeSelf);
            healthHud.Setup(playerController.Health, playerController.PlayerColor);
            healthHud.gameObject.SetActive(true);
        }
    }
}