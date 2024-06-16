using healthSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    static int DEAD_PARAMETER_HASH = Animator.StringToHash("Dead");

    [SerializeField] Health _health;
    [SerializeField] AttackBase _initialWeapon;
    [SerializeField] PlayerAim _playerAim;
    [SerializeField] Animator _playerAnimator;
    [SerializeField] PlayerMovement _movement;

    public Health Health => _health;
    public Color PlayerColor { get; private set; }

    void Start()
    {
        _playerAim.UpdateAttack(_initialWeapon);
        _health.OnDeath += () => _movement.enabled = false;
        _health.OnDeath += () => _playerAnimator.SetTrigger(DEAD_PARAMETER_HASH);
    }

    public void Setup(PlayerData playerData)
    {
        PlayerColor = playerData.Color;
        _playerAim.SetIndicatorStyle(PlayerColor);
        _playerAnimator.runtimeAnimatorController = playerData.AnimatorController;
    }

    public void OnAttack(InputValue value)
    {
        _playerAim.CurrentAttack.TryAttack();
    }
}