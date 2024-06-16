using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] AttackBase _initialWeapon;
    [SerializeField] PlayerAim _playerAim;

    void Start()
    {
        _playerAim.UpdateAttack(_initialWeapon);
    }

    public void OnAttack(InputValue value)
    {
        _playerAim.CurrentAttack.Attack();
        // var delta = value.Get<Vector2>();
        // Debug.Log($"Received {delta}");
        // transform.position += (Vector3) delta * Time.deltaTime * _speed;
    }
}