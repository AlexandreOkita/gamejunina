using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    static int SPEED_PARAMETER_HASH = Animator.StringToHash("Speed");

    [SerializeField] float _speed;
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] Animator _animator;
    [SerializeField] GameObject _view;

    Bounds _bounds;

    public void SetupBounds(Bounds bounds) => _bounds = bounds;

    void Update()
    {
        var delta = _playerInput.actions["Move"].ReadValue<Vector2>();
        if (_bounds == null || !_bounds.Contains(transform.position + (Vector3) delta * Time.deltaTime * _speed)) return;

        transform.position += (Vector3) delta * Time.deltaTime * _speed;

        _animator.SetFloat(SPEED_PARAMETER_HASH, delta.magnitude);

        if (delta.magnitude > 0.05f)
        {
            _view.transform.right = Vector2.Dot(delta, Vector2.right) * Vector2.right;
        }
    }
}
