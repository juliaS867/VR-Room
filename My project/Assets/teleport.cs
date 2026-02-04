using UnityEngine;
using UnityEngine.InputSystem;

public class teleport : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Vector3 inside = new Vector3(0, 0, 0);
    private Vector3 outside = new Vector3(0, 0, -20);
    private bool isInside = true;
    public InputActionReference action;
    
    void Start()
    {
        transform.position = inside;
        action.action.Enable();
        action.action.performed += changeView;
    }

    void changeView(InputAction.CallbackContext ctx)
    {
        if (isInside)
        {
            transform.position = outside;
            isInside = false;
        }
        else
        {
            transform.position = inside;
            isInside = true;
        }
    }
}
