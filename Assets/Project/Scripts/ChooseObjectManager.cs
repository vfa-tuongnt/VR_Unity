using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ChooseObjectManager : MonoBehaviour
{
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


    public void ChooseObject(ObjectDataSO objectDataSO)
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

        }
        else
        {
            Debug.Log("Wrong! Please choose again!");
        }
    }
}
