using UnityEngine;
using UnityEngine.EventSystems; // Required for event handlers

public class ObjectInteractable : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    // Define events for onClick and onHover
    public delegate void InteractAction();
    public event InteractAction onClick;
    public event InteractAction onHover;

    // Method called when the object is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Object Clicked!");
        onClick?.Invoke(); // Invoke the onClick event
    }

    // Method called when the mouse hovers over the object
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse Hover Over Object!");
        onHover?.Invoke(); // Invoke the onHover event
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
