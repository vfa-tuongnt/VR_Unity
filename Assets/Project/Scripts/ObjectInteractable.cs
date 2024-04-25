using UnityEngine;
using UnityEngine.EventSystems; // Required for event handlers

public class ObjectInteractable : MonoBehaviour
{
    // Define events for onClick and onHover
    public delegate void InteractAction();
    public event InteractAction onClick;
    public event InteractAction onHover;

    void OnMouseEnter()
    {
        Debug.Log("Mouse Hover Over Object!");
        onHover?.Invoke(); // Invoke the onHover event
    }
    void OnMouseDown()
    {
        Debug.Log("Object Clicked!");
        onClick?.Invoke(); // Invoke the onClick event
    }
    void OnMouseExit()
    {
        
    }

    // Example methods for onClick and onHover actions
    void DefaultClickAction()
    {
        Debug.Log("Performing default click action");
    }

    void DefaultHoverAction()
    {
        Debug.Log("Performing default hover action");
    }

    void Start()
    {
        // Subscribe some default methods to these actions
        if (onClick == null)
        {
            onClick += DefaultClickAction;
        }
        if (onHover == null)
        {
            onHover += DefaultHoverAction;
        }
    }
}
