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
    public Transform parent;
    List<CheckElementUI> checkElementUIList = new List<CheckElementUI>();
    void Start()
    {
        checkElementUI.SetText("Choose the correct object", false);
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
    }


    public void ChooseObject(ObjectDataSO objectDataSO, Vector3 position)
    {
        if(objectDataSOList.Contains(objectDataSO))
        {
            chosenList.Add(objectDataSO);
            Debug.Log("Congratulations you you choose the correct object " + objectDataSO.objectName + "!");

            var find = checkElementUIList.Find(x => x.objectName == objectDataSO.objectName);
            if(find != null)
            {
                find.SetText(objectDataSO.objectName, true);
            }
            Transform checkUI = Instantiate(Resources.Load("Prefabs/CheckUI")).GetComponent<Transform>();
            checkUI.GetComponentInChildren<Image>().sprite = correctSprite;
            checkUI.position = position + new Vector3(0, 0.8f, -0.1f);
            Destroy(checkUI.gameObject, 1f);
        }
        else
        {
            Debug.Log("Wrong! Please choose again!");
            Transform checkUI = Instantiate(Resources.Load("Prefabs/CheckUI")).GetComponent<Transform>();
            checkUI.GetComponentInChildren<Image>().sprite = wrongSprite;
            checkUI.position = position + new Vector3(0, 0.8f, -0.1f);
            Destroy(checkUI.gameObject, 1f);
        }
    }
}
