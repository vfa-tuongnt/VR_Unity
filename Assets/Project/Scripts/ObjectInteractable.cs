using UnityEngine;
using UnityEngine.EventSystems; // Required for event handlers

public class ObjectInteractable : MonoBehaviour
{
    public event InteractAction onClick;
    public event InteractAction onHover;
    public event InteractAction onExit;

    // Define events for onClick and onHover
    public delegate void InteractAction();
    public ObjectInfoPanel objectInfoPanel;
    public string title;
    public string text;

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
        onExit?.Invoke();        
    }

    // Example methods for onClick and onHover actions
    void DefaultClickAction()
    {
        
    }

    void DefaultHoverAction()
    {
        objectInfoPanel.Show(true);
        objectInfoPanel.SetTitle(title);
        objectInfoPanel.SetDescription(text);
    }

    void DefaultExitAction()
    {
        objectInfoPanel.Show(false);
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
        if(onExit == null)
        {
            onExit += DefaultExitAction;
        }
        objectInfoPanel.Show(false);

    }
}
