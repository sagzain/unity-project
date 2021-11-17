using UnityEngine;

public class CursorSettings : MonoBehaviour
{

    [SerializeField] private Texture2D _crosshairCursor;

    private Vector2 _zero = Vector2.zero;
    private CursorMode _cursorMode = CursorMode.Auto;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    
    void OnMouseEnter()
    {
        Cursor.SetCursor(_crosshairCursor, _zero, _cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, _zero, _cursorMode);
    }
}
