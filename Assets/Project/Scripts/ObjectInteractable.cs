using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit; // Required for event handlers

public class ObjectInteractable : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable grabInteractable;
    [SerializeField] private ObjectDataSO objectDataSO;
    [SerializeField] private Outline outline;
    public event InteractAction onClick;
    public event InteractAction onHover;
    public event InteractAction onExit;
    ObjectInfoPanel objectInfoPanel;
    
    // Define events for onClick and onHover
    public delegate void InteractAction();

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
        ChooseObjectManager.Instance.ChooseObject(this.objectDataSO, this.transform.position);
    }

    void DefaultHoverAction()
    {
        objectInfoPanel = ObjectInfoPanel.Create();
        objectInfoPanel.SetTitle(objectDataSO.objectName);
        objectInfoPanel.SetDescription(objectDataSO.objectDescription);
        objectInfoPanel.Show(true, this.transform.position + new Vector3(0, 0.8f, 0));
    }

    void DefaultExitAction()
    {
        objectInfoPanel.Show(false, this.transform.position);
    }

    void Start()
    {
        grabInteractable.hoverEntered.AddListener((call) => DefaultHoverAction());
        grabInteractable.hoverExited.AddListener((call) => DefaultExitAction());
        grabInteractable.selectEntered.AddListener((call) => DefaultClickAction());
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
        outline.enabled = false;
    }
}
