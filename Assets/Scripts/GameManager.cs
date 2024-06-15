using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerManager _playerManager;

    static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }

            return _instance;
        }

        private set
        {
            _instance = value;
        }
    }

    public event Action OnGameStarted;

    public List<GameObject> Players => _playerManager.Players;

    bool _isRunning;

    void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        if (_isRunning || _playerManager.Players.Count == 0) return;

        OnGameStarted?.Invoke();
        _isRunning = true;
        Debug.Log("Game started!");
    }
}
