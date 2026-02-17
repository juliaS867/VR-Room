using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class bowlBallsSript : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor bowlSocket;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor ballSocket;

    public GameObject ballObject;
    public GameObject memopaper2;
    public GameObject memopaper3;   // <-- NEW memo pad 3

    bool bowlPlaced = false;
    bool ballPlaced = false;

    void Start()
    {
        // Hide everything at start
        ballSocket.socketActive = false;

        ballObject.SetActive(false);
        memopaper2.SetActive(false);
        memopaper3.SetActive(false);   // hide memo3 too
    }

    void OnEnable()
    {
        bowlSocket.selectEntered.AddListener(OnBowlSnapped);
        ballSocket.selectEntered.AddListener(OnBallSnapped); // listen for ball snap
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
    }
}
