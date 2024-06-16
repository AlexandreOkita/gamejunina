using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameHud _gameHud;
    [SerializeField] List<Color> _playerColors;

    public readonly List<PlayerController> Players = new();

    public void OnPlayerJoined(PlayerInput player)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.Setup(_playerColors[Players.Count]);
        _gameHud.ActivateHealthForPlayer(playerController);

        Players.Add(playerController);
        Debug.Log($"Player joined. Count {Players.Count}", player);
    }
}
