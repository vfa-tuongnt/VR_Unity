using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] private List<ObjectDataSO> objectDataSOList = new List<ObjectDataSO>();

    public void ChooseObject(ObjectDataSO objectDataSO)
    {
        if(objectDataSOList.Contains(objectDataSO))
        {
            Debug.Log("Congratulations you you choose the correct object " + objectDataSO.objectName + "!");
        }
        else
        {
            Debug.Log("Wrong! Please choose again!");
        }
    }
}
