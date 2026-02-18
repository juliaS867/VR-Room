using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class DoorSocketOpener : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor doorSocket;
    public Animator doorAnimator;

    public GameObject winCanvas;       // WinCanvas GameObject
    public CanvasGroup winCanvasGroup; // CanvasGroup component on WinCanvas
    

    private bool opened = false;

    void OnEnable()
    {
        doorSocket.selectEntered.AddListener(OnSnapped);
    }

    void OnDisable()
    {
        doorSocket.selectEntered.RemoveListener(OnSnapped);
    }

    void OnSnapped(SelectEnterEventArgs args)
    {
        if (opened) return;

        if (args.interactableObject.transform.CompareTag("puppy"))
        {
            opened = true;

            GameObject dog = args.interactableObject.transform.gameObject;

            // Hide dog instantly
            foreach (Renderer r in dog.GetComponentsInChildren<Renderer>())
                r.enabled = false;

            foreach (Collider c in dog.GetComponentsInChildren<Collider>())
                c.enabled = false;

            // Show WinCanvas
            winCanvas.SetActive(true);
            winCanvasGroup.alpha = 1f;

            // Start fade coroutine (2 seconds)
            StartCoroutine(FadeOutWinCanvas(10f));

            // Open door
            doorAnimator.SetTrigger("OpenDoor");
        }
    }

    private IEnumerator FadeOutWinCanvas(float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            winCanvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsed / duration);
            yield return null;
        }

        winCanvas.SetActive(false); // Hide canvas completely
    }
}