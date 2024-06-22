using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameHud : MonoBehaviour
    {
        [SerializeField] List<HealthHud> _healthHuds;
        [SerializeField] TMP_Text _waveText;

        public void Start()
        {
            _waveText.text = "Wave 1";
            LevelManager.Instance.NewLevelStarted += (wave) =>
            {
                _waveText.text = $"Wave {wave}";
            };
        }


        public void ActivateHealthForPlayer(PlayerController playerController)
        {
            HealthHud healthHud = _healthHuds.First(hud => !hud.gameObject.activeSelf);
            healthHud.Setup(playerController.Health, playerController.PlayerColor);
            healthHud.gameObject.SetActive(true);
        }
    }
}