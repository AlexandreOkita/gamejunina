using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public readonly List<GameObject> Players = new();

    public void OnPlayerJoined(PlayerInput player)
    {
        Players.Add(player.gameObject);
        Debug.Log($"Player joined. Count {Players.Count}", player);
    }
}
