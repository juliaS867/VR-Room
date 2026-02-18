using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class bowlBallsScript : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor bowlSocket;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor ballSocket;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor doorSocket; // Door socket

    public GameObject ballObject;
    public GameObject memopaper2;
    public GameObject memopaper3;   

    [Header("Dog Settings")]
    public GameObject dogObject;              // Your dog GameObject
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable dogGrab;        // Dog's XRGrabInteractable
    public Rigidbody dogRigidbody;            // Dog's Rigidbody

    bool bowlPlaced = false;
    bool ballPlaced = false;

    void Start()
    {
        // Hide everything at start
        ballSocket.socketActive = false;

        if (doorSocket != null)
            doorSocket.socketActive = false; // Disable door socket initially

        ballObject.SetActive(false);
        memopaper2.SetActive(false);
        memopaper3.SetActive(false);

        // Lock dog so it can't move / clip
        dogGrab.enabled = false;
        dogRigidbody.isKinematic = true; // cannot be moved
    }

    void OnEnable()
    {
        bowlSocket.selectEntered.AddListener(OnBowlSnapped);
        ballSocket.selectEntered.AddListener(OnBallSnapped); 
    }

    void OnDisable()
    {
        bowlSocket.selectEntered.RemoveListener(OnBowlSnapped);
        ballSocket.selectEntered.RemoveListener(OnBallSnapped);
    }

    void OnBowlSnapped(SelectEnterEventArgs args)
    {
        if (bowlPlaced) return;

        bowlPlaced = true;

        // Enable ball socket + show ball + memo2
        ballSocket.socketActive = true;

        ballObject.SetActive(true);
        memopaper2.SetActive(true);
    }

    void OnBallSnapped(SelectEnterEventArgs args)
    {
        if (ballPlaced) return;

        ballPlaced = true;

        // Show memo3 after ball is placed
        memopaper3.SetActive(true);

        // Unlock dog so it can be grabbed and snapped to door
        dogGrab.enabled = true;
        dogRigidbody.isKinematic = false;

        // Unlock door socket now that ball is placed
        if (doorSocket != null)
            doorSocket.socketActive = true;
    }
}