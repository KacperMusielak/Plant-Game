using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(SwipeManager))]
public class InputController : MonoBehaviour
{
    //public Player OurPlayer; // Perhaps your playerscript?

    void Start()
    {
        SwipeManager swipeManager = GetComponent<SwipeManager>();
        SwipeManager.OnSwipeDetected.AddListener(HandleSwipe);
    }

    void HandleSwipe(Swipe swipe, Vector2 swipeVelocity)
    {
        if (swipe == Swipe.Up)
        {
            Debug.unityLogger.Log("Swipe Up Detected");
        }
        else if (swipe == Swipe.Right)
        {
            Debug.unityLogger.Log("Swipe Right Detected");
        }
        else if (swipe == Swipe.Down)
        {
            Debug.unityLogger.Log("Swipe Down Detected");
        }
        else if (swipe == Swipe.Left)
        {
            Debug.unityLogger.Log("Swipe Left Detected");
        }
    }
}