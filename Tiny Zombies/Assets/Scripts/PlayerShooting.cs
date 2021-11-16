using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Vector3 _movementInput;

    void Awake()
    {
        // Cursor.lockState = CursorLockMode.Confined;
    }

    void Update() 
    {
        Ray ray = Camera.main.ScreenPointToRay(_movementInput);
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            transform.LookAt(hit.point);
        }
    }

    public void OnMouseMovement(InputAction.CallbackContext value)
    {
        _movementInput = value.ReadValue<Vector2>();
    }

    public void OnMouseClick(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
            Instantiate(_bulletPrefab, Vector3.up + transform.position, transform.rotation);
        }
    }
}
