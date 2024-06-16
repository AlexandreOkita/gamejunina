using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] PlayerInput _playerInput;

    void Update()
    {
        var delta = _playerInput.actions["Move"].ReadValue<Vector2>();
        transform.position += (Vector3) delta * Time.deltaTime * _speed;
    }
}
