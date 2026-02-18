using UnityEngine;

public class DoorProximityOpen : MonoBehaviour
{
    public Transform door;        // Door object
    public float openAngle = 90f; // Y rotation
    public float smooth = 2f;     // Speed
    private bool isOpening = false;
    private Quaternion closedRotation;

    void Start()
    {
        closedRotation = door.localRotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Puppy") && !isOpening)
        {
            isOpening = true;
            StopAllCoroutines();
            StartCoroutine(OpenDoor());
        }
    }

    System.Collections.IEnumerator OpenDoor()
    {
        Quaternion targetRot = Quaternion.Euler(0, openAngle, 0);
        while (Quaternion.Angle(door.localRotation, targetRot) > 0.1f)
        {
            door.localRotation = Quaternion.Slerp(door.localRotation, targetRot, Time.deltaTime * smooth);
            yield return null;
        }
        door.localRotation = targetRot;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Puppy"))
        {
            StopAllCoroutines();
            StartCoroutine(CloseDoor());
        }
    }

    System.Collections.IEnumerator CloseDoor()
    {
        isOpening = false;
        while (Quaternion.Angle(door.localRotation, closedRotation) > 0.1f)
        {
            door.localRotation = Quaternion.Slerp(door.localRotation, closedRotation, Time.deltaTime * smooth);
            yield return null;
        }
        door.localRotation = closedRotation;
    }
}