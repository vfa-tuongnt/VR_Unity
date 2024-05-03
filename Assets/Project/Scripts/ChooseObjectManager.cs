using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChooseObjectManager : MonoBehaviour
{
    public Sprite correctSprite, wrongSprite;
    private static ChooseObjectManager _instance;
    public static ChooseObjectManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ChooseObjectManager>();
            }
            return _instance;
        }
    }

    public List<ObjectDataSO> objectDataSOList = new List<ObjectDataSO>();
    public List<ObjectDataSO> chosenList = new List<ObjectDataSO>();
    
    public CheckElementUI checkElementUI;
    public Button resetBtn;
    public Transform parent;
    List<CheckElementUI> checkElementUIList = new List<CheckElementUI>();
    List<ObjectInteractable> objectInteractableList = new List<ObjectInteractable>();
    private ObjectDataSO selectedObjectData;

    void Start()
    {
        checkElementUI.SetText("Choose the correct object", false);
        checkElementUI.gameObject.SetActive(false);
        InitUI();
    }

    void InitUI(){
        foreach (ObjectDataSO objectDataSO in objectDataSOList)
        {
            CheckElementUI checkElementUI = Instantiate(this.checkElementUI, parent);
            checkElementUI.gameObject.SetActive(true);
            checkElementUI.SetText(objectDataSO.objectName, false);
            checkElementUIList.Add(checkElementUI);
        }
        resetBtn.onClick.AddListener(Reset);
    }

    public void SetSelectedObject(ObjectDataSO objectDataSO)
    {
        this.selectedObjectData = objectDataSO;
    }
    public void ClearSelectedObject()
    {
        this.selectedObjectData = null;
    }
    public ObjectDataSO GetSelectedObject()
    {
        return this.selectedObjectData;
    }

    public void AddChosenObject(ObjectInteractable objectInteractable)
    {
        objectInteractableList.Add(objectInteractable);
    }

    public void Reset()
    {
        foreach(var objectInteractable in objectInteractableList)
        {
            objectInteractable.gameObject.SetActive(true);
        }
        foreach(var checkElementUI in checkElementUIList)
        {
            checkElementUI.SetChoose(false);
        }
        objectInteractableList.Clear();
        chosenList.Clear();
    }

    public bool ChooseObject(Vector3 position)
    {
        if(objectDataSOList.Contains(selectedObjectData))
        {
            chosenList.Add(selectedObjectData);
            Debug.Log("Congratulations you you choose the correct object " + selectedObjectData.objectName + "!");

            var find = checkElementUIList.Find(x => x.objectName == selectedObjectData.objectName);
            if(find != null)
            {
                find.SetText(selectedObjectData.objectName, true);
            }
            Transform checkUI = Instantiate(Resources.Load("Prefabs/CheckUI")).GetComponent<Transform>();
            checkUI.GetComponentInChildren<Image>().sprite = correctSprite;
            checkUI.position = position + new Vector3(0, 0.8f, -0.1f);
            Destroy(checkUI.gameObject, 1f);
            return true;
        }
        else
        {
            Debug.Log("Wrong! Please choose again!");
            Transform checkUI = Instantiate(Resources.Load("Prefabs/CheckUI")).GetComponent<Transform>();
            checkUI.GetComponentInChildren<Image>().sprite = wrongSprite;
            checkUI.position = position + new Vector3(0, 0.8f, -0.1f);
            Destroy(checkUI.gameObject, 1f);
            return false;
        }
    }
}
