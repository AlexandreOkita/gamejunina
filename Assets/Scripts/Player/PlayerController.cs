using healthSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    static int DEAD_PARAMETER_HASH = Animator.StringToHash("Dead");

    
    [SerializeField] AttackBase _initialWeapon;
    [SerializeField] PlayerAim _playerAim;
    [SerializeField] Animator _playerAnimator;
    [SerializeField] PlayerAttributes _attributes;
    [SerializeField] SkillCaster skillCaster;

    public PlayerAttributes Attributes => _attributes;
    public Health Health => _attributes.Health;
    public Color PlayerColor { get; private set; }

    void Start()
    {
        _playerAim.UpdateAttack(_initialWeapon);
        _attributes.Health.OnDeath += DisablePlayer;
        _attributes.Health.OnDeath += () => _playerAnimator.SetTrigger(DEAD_PARAMETER_HASH);
        LevelManager.Instance.NewLevelStarted += () =>
        {
            _attributes.Health.HealDamage(_attributes.Regen);
        };
    }

    void DisablePlayer()
    {
        _attributes.Movement.enabled = false;
        _playerAim.AimParent.gameObject.SetActive(false);
        _playerAim.enabled = false;
    }

    public void Setup(PlayerData playerData, Bounds playerBounds)
    {
        PlayerColor = playerData.Color;
        _playerAim.SetIndicatorStyle(PlayerColor);
        _playerAnimator.runtimeAnimatorController = playerData.AnimatorController;
        _attributes.Movement.SetupBounds(playerBounds);
    }

    public void UpdateWeapon(AttackBase weapon)
    {
        _playerAim.UpdateAttack(weapon);
    }

    public void OnAttack(InputValue value)
    {
        if (!Health.IsAlive) return;
        if (Time.timeScale < 0.1f) return;

        _playerAim.CurrentAttack.TryAttack(Attributes.AttackSpeed, Attributes.Attack);
    }
}