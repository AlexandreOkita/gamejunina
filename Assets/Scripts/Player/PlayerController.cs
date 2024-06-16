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

    private float attackMod = 1f;
    private float attackSpeedMod = 1f;

    void Start()
    {
        _playerAim.UpdateAttack(_initialWeapon);
        _health.OnDeath += () => _movement.enabled = false;
        _health.OnDeath += () => _playerAnimator.SetTrigger(DEAD_PARAMETER_HASH);
    }

    public void Setup(PlayerData playerData, Bounds playerBounds)
    {
        PlayerColor = playerData.Color;
        _playerAim.SetIndicatorStyle(PlayerColor);
        _playerAnimator.runtimeAnimatorController = playerData.AnimatorController;
        _movement.SetupBounds(playerBounds);
    }

    public void OnAttack(InputValue value)
    {
        _playerAim.CurrentAttack.TryAttack(attackSpeedMod, attackMod);
    }

    public void upgradeAttack()
    {
        attackMod += 0.5f;
    }

    public void upgradeAttackSpeed()
    {
        attackSpeedMod *= 0.1f;
    }

    public void upgradeHealth()
    {
        _health.maxHealth += 25;
    }
}