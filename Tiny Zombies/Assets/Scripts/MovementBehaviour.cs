using UnityEngine;
using UnityEngine.InputSystem;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5.0f;
    [SerializeField] private Vector2 _movementInput;

    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        var velocity = _movementSpeed * Time.deltaTime;
        var horizontal = _movementInput.x * velocity;
        var vertical = _movementInput.y * velocity;

        transform.position += new Vector3(horizontal, 0, vertical);
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        _movementInput = value.ReadValue<Vector2>();

        var moveAmount = Mathf.Clamp01(Mathf.Abs(_movementInput.x) + Mathf.Abs(_movementInput.y));
        _animator.SetFloat("velocity", moveAmount);  
    }
}
