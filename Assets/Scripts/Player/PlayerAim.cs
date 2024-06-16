using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] Transform _aimParent;
    [SerializeField] Transform _attackParent;
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] SpriteRenderer _aimIndicatorSprite;

    public AttackBase CurrentAttack { get; private set; }
    public Transform AimParent => _aimParent;

    bool _isMouseBased;
    Camera _mainCamera;

    void Start()
    {
        _isMouseBased = _playerInput.currentControlScheme == "Keyboard&Mouse";
        _mainCamera = Camera.main;

        Debug.Log($"Detected using mouse {_isMouseBased}");
    }

    void Update()
    {
        Vector2 desiredLookDirection = CalculateCurrentLookDirection();
        if (desiredLookDirection.Equals(Vector3.zero)) return;

        _aimParent.transform.right = desiredLookDirection;
    }

    Vector2 CalculateCurrentLookDirection()
    {
        if (!_isMouseBased) return _playerInput.actions["Look"].ReadValue<Vector2>();

        Vector2 currentPos = transform.position;
        Vector2 pointerPos = _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        return pointerPos - currentPos;
    }

    public void UpdateAttack(AttackBase attack)
    {
        if (CurrentAttack != null) Destroy(CurrentAttack);

        CurrentAttack = Instantiate(attack, _attackParent);
    }

    public void SetIndicatorStyle(Color color) => _aimIndicatorSprite.color = color;
}