using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    public Light light;
    public InputActionReference action;

    void Start()
    {
        light = GetComponent<Light>();
        action.action.Enable();
        action.action.performed += ChangeLight;
    }


    void ChangeLight(InputAction.CallbackContext ctx)
    {
        if (light.color == Color.white)
        {
            light.color = Color.violet;
        }
        else
        {
            light.color = Color.white;
        }
    }
}