using System.Collections;
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
    [SerializeField] SpriteRenderer _sprite;
    public SkillCaster SkillCaster => skillCaster;

    public PlayerAttributes Attributes => _attributes;
    public Health Health => _attributes.Health;
    public Color PlayerColor { get; private set; }

    private bool _isInvisible = false;
    public bool IsInvisible => _isInvisible;

    void Start()
    {
        _playerAim.UpdateAttack(_initialWeapon);
        _attributes.Health.OnDeath += DisablePlayer;
        _attributes.Health.OnDeath += () => _playerAnimator.SetTrigger(DEAD_PARAMETER_HASH);
        LevelManager.Instance.NewLevelStarted += (_) =>
        {
            _attributes.Health.HealDamage(_attributes.Regen);
        };
    }

    public void TurnOnInvisibility(float duration)
    {
        _isInvisible = true;
        StartCoroutine(TurnOffInvisibilityAfterDelay(duration));
    }

    private IEnumerator TurnOffInvisibilityAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _isInvisible = false;
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

    public void StartBlink(float duration, float blinkInterval)
    {
        StartCoroutine(Blink(duration, blinkInterval));
    }

    private IEnumerator Blink(float duration, float blinkInterval)
    {
        float elapsed = 0f;
        bool isVisible = true;

        while (elapsed < duration)
        {
            isVisible = !isVisible;
            _sprite.enabled = isVisible;

            yield return new WaitForSeconds(blinkInterval);
            elapsed += blinkInterval;
        }

        _sprite.enabled = true;
    }
}