using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object Data SO")]
public class ObjectDataSO : ScriptableObject
{
    public string objectName;
    public string objectDescription;
    public GameObject objectPrefab;
}
