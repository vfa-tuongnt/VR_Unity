using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CheckElementUI : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI text;
    public string objectName;
    public void SetText(string text, bool haveCheck)
    {
        objectName = text;
        this.text.text = text;
        image.enabled = haveCheck;
    }
}
