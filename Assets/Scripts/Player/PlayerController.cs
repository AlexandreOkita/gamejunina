using healthSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] AttackBase _initialWeapon;
    [SerializeField] PlayerAim _playerAim;
    [SerializeField] SpriteRenderer _playerSprite;

    public Health Health => _health;
    public Color PlayerColor { get; private set; }

    private float attackMod = 1f;
    private float attackSpeedMod = 1f;

    void Start()
    {
        _playerAim.UpdateAttack(_initialWeapon);
    }

    public void Setup(Color color)
    {
        PlayerColor = color;
        _playerAim.SetIndicatorStyle(color);
        _playerSprite.material.SetColor("_FinalColor", color);
    }

    public void OnAttack(InputValue value)
    {
        _playerAim.CurrentAttack.TryAttack(attackSpeedMod, attackMod);
        // var delta = value.Get<Vector2>();
        // Debug.Log($"Received {delta}");
        // transform.position += (Vector3) delta * Time.deltaTime * _speed;
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