using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] PlayerManager _playerManager;

        public event Action OnGameStarted;

        public PlayerManager PlayerManager => _playerManager;

        bool _isRunning;

        void Update()
        {
            if (_isRunning || _playerManager.Players.Count == 0) return;

            OnGameStarted?.Invoke();
            _isRunning = true;
            Debug.Log("Game started!");
        }
    }
}