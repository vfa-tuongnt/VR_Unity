using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit; // Required for event handlers

public class ObjectInteractable : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable grabInteractable;
    [SerializeField] private InputActionReference onLeftClickAction, onRightClickAction;
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
        onHover?.Invoke(); // Invoke the onHover event
    }
    void OnMouseDown()
    {
        onClick?.Invoke(); // Invoke the onClick event
    }
    void OnMouseExit()
    {
        onExit?.Invoke();        
    }

    // Example methods for onClick and onHover actions
    void DefaultClickAction()
    {
        if(ChooseObjectManager.Instance.GetSelectedObject() == this.objectDataSO)
            if(ChooseObjectManager.Instance.ChooseObject(this.transform.position))
            {
                DefaultExitAction();
                this.gameObject.SetActive(false);
                ChooseObjectManager.Instance.AddChosenObject(this);
            }
    }

    void DefaultHoverAction()
    {
        if(objectInfoPanel != null) 
        {
            DefaultExitAction();
        }
        outline.enabled = true;
        objectInfoPanel = ObjectInfoPanel.Create();
        objectInfoPanel.SetTitle(objectDataSO.objectName);
        objectInfoPanel.SetDescription(objectDataSO.objectDescription);
        objectInfoPanel.Show(true, this.transform.position + new Vector3(0, 0.8f, 0));
        ChooseObjectManager.Instance.SetSelectedObject(this.objectDataSO);
    }

    void DefaultExitAction()
    {
        outline.enabled = false;
        objectInfoPanel.Show(false, this.transform.position);
        ChooseObjectManager.Instance.ClearSelectedObject();
    }

    void Start()
    {
        grabInteractable.hoverEntered.AddListener((call) => DefaultHoverAction());
        grabInteractable.hoverExited.AddListener((call) => DefaultExitAction());
        grabInteractable.selectEntered.AddListener((call) => DefaultExitAction());

        onLeftClickAction.action.performed += (action) => DefaultClickAction();
        onRightClickAction.action.performed += (action) => DefaultClickAction();

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
