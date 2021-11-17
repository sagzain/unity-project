using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Vector3 _movementInput;

    [SerializeField]private Transform _weaponOutput;

    void Awake()
    {
        _weaponOutput = GameObject.Find("Pistol").transform.GetChild(0).gameObject.transform;
    }

    void Update() 
    {
        if(Player.Instance.IsAlive)
        {
            Ray ray = Camera.main.ScreenPointToRay(_movementInput);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                transform.LookAt(hit.point);
            }
        }
    }

    public void OnMouseMovement(InputAction.CallbackContext value)
    {
        if(Player.Instance.IsAlive)
        {
            _movementInput = value.ReadValue<Vector2>();
        }
    }

    public void OnMouseClick(InputAction.CallbackContext value)
    {
        if(value.performed && Player.Instance.IsAlive)
        {
            Instantiate(_bulletPrefab, _weaponOutput.position, transform.rotation);
        }
    }
}
