using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameHud _gameHud;
    [SerializeField] List<Color> _playerColors;
    [SerializeField] List<PlayerData> _playerConfigs;
    [SerializeField] Collider2D _playerBounds;

    public readonly List<PlayerController> Players = new();

    public void OnPlayerJoined(PlayerInput player)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.Setup(_playerConfigs[Players.Count], _playerBounds.bounds);
        _gameHud.ActivateHealthForPlayer(playerController);

        Players.Add(playerController);
        Debug.Log($"Player joined. Count {Players.Count}", player);
    }
}

[Serializable]
public class PlayerData
{
    [SerializeField] Color _color;
    [SerializeField] AnimatorOverrideController _spritesheet;

    public Color Color => _color;
    public AnimatorOverrideController AnimatorController => _spritesheet;
}
