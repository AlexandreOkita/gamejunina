using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] PlayerInput _playerInput;

    public void OnMove(InputValue value)
    {
        // var delta = value.Get<Vector2>();
        // Debug.Log($"Received {delta}");
        // transform.position += (Vector3) delta * Time.deltaTime * _speed;
    }

    void Update()
    {
        var delta = _playerInput.actions["Move"].ReadValue<Vector2>();
        transform.position += (Vector3) delta * Time.deltaTime * _speed;
    }
}
