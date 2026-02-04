using UnityEngine;

public class constantrotation : MonoBehaviour
{
    
    public float degreesPerSecond = 5.0f; 

    void Update()
    {
        transform.Rotate(0, degreesPerSecond * Time.deltaTime, 0);
    }
}
