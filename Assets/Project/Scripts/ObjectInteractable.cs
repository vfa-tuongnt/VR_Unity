using UnityEngine;
using UnityEngine.EventSystems; // Required for event handlers

public class ObjectInteractable : MonoBehaviour
{
    [SerializeField] private ObjectDataSO objectDataSO;
    [SerializeField] private Outline outline;
    public event InteractAction onClick;
    public event InteractAction onHover;
    public event InteractAction onExit;

    // Define events for onClick and onHover
    public delegate void InteractAction();
    public ObjectInfoPanel objectInfoPanel;

    void OnMouseEnter()
    {
        outline.enabled = true;
        onHover?.Invoke(); // Invoke the onHover event
    }
    void OnMouseDown()
    {
        onClick?.Invoke(); // Invoke the onClick event
    }
    void OnMouseExit()
    {
        outline.enabled = false;
        onExit?.Invoke();        
    }

    // Example methods for onClick and onHover actions
    void DefaultClickAction()
    {
        ChooseObjectManager.Instance.ChooseObject(this.objectDataSO);
    }

    void DefaultHoverAction()
    {
        objectInfoPanel.Show(true);
        objectInfoPanel.SetTitle(objectDataSO.objectName);
        objectInfoPanel.SetDescription(objectDataSO.objectDescription);
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
        outline.enabled = false;
    }
}
