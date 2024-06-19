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
    private float _regen = 0;

    void Start()
    {
        _playerAim.UpdateAttack(_initialWeapon);
        _health.OnDeath += DisablePlayer;
        _health.OnDeath += () => _playerAnimator.SetTrigger(DEAD_PARAMETER_HASH);
        LevelManager.Instance.NewLevelStarted += () =>
        {
            _health.HealDamage(_regen);
        };
    }

    void DisablePlayer()
    {
        _movement.enabled = false;
        _playerAim.AimParent.gameObject.SetActive(false);
        _playerAim.enabled = false;
    }

    public void Setup(PlayerData playerData, Bounds playerBounds)
    {
        PlayerColor = playerData.Color;
        _playerAim.SetIndicatorStyle(PlayerColor);
        _playerAnimator.runtimeAnimatorController = playerData.AnimatorController;
        _movement.SetupBounds(playerBounds);
    }

    public void UpdateWeapon(AttackBase weapon)
    {
        _playerAim.UpdateAttack(weapon);
    }

    public void OnAttack(InputValue value)
    {
        if (!Health.IsAlive) return;
        if (Time.timeScale < 0.1f) return;

        _playerAim.CurrentAttack.TryAttack(attackSpeedMod, attackMod);
    }

    public void upgradeAttack()
    {
        attackMod += 0.5f;
    }

    public void upgradeAttackSpeed()
    {
        attackSpeedMod *= 0.5f;
    }

    public void upgradeHealth()
    {
        _health.SetMaxHealth(_health.MaxHealth + 25);
    }

    public void upgradeSpeed()
    {
        _movement.UpdateSpeed((float) 1.5);
    }

    public void upgradeRegen()
    {
        _regen += 25;
    }
}