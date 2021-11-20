using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    private Vector3 _movementInput;
    private Transform _weaponOutput;

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
                var target = hit.transform.tag == "Enemy" ? hit.transform.gameObject.transform.position : hit.point;
                Debug.DrawLine(ray.origin, target, Color.red);
                transform.LookAt(target);
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
