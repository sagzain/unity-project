using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    private GameObject _weapon;
    private Vector3 _mouseInput;    

    void Awake()
    {
        _weapon = GameObject.FindWithTag("Weapon");
    }

    void Update() 
    {
        // _mouseInput.z = Camera.main.farClipPlane * .5f;

        // var worldPos = Camera.main.ScreenToWorldPoint(_mouseInput);
        // Debug.DrawRay(Camera.main.transform.position, worldPos, Color.green);
 
        if(Player.Instance.IsAlive)
        {
            Ray ray = Camera.main.ScreenPointToRay(_mouseInput);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit))
            {
                var target = hit.transform.tag == "Enemy" ? hit.transform.gameObject.transform.position : hit.point;
                Debug.DrawLine(ray.origin, target, Color.red);
                transform.LookAt(target);
                // transform.Rotate(new Vector3(0, 2.75f,0));
            }
        }
    }

    public void OnMouseMovement(InputAction.CallbackContext value)
    {
        if(Player.Instance.IsAlive)
        {
            _mouseInput = value.ReadValue<Vector2>();
        }
    }

    public void OnMouseClick(InputAction.CallbackContext value)
    {
        if(value.performed && Player.Instance.IsAlive)
        {
            _weapon.GetComponent<Revolver>().Shoot();
        }
    }
}
