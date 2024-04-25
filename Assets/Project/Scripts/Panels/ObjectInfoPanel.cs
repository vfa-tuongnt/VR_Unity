using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening; // Include the TextMeshPro namespace

public class ObjectInfoPanel : MonoBehaviour
{
    // TMP Text field for displaying the description
    public TMP_Text descriptionText;
    private float originalScale;
    public TMP_Text title;
    // Start is called before the first frame update
    void Start()
    {
        // Optionally initialize the descriptionText with some default text
        if (descriptionText != null)
            descriptionText.text = "Demo content.";
        
        originalScale = this.transform.localScale.x;
    }

    // Function to set the text of the description field
    public void SetDescription(string description)
    {
        if (descriptionText != null)
            descriptionText.text = description;
        else
            Debug.LogError("Description Text component not set on " + gameObject.name);
    }

    public void SetTitle(string title)
    {
        this.title.text = title;
    }
        

    public void Show(bool value)
    {
        if(value)
        {
            this.transform.localScale = Vector3.zero;
            this.transform.DOScale(originalScale, 0.5f);
        }
        else
        {
            this.transform.DOScale(0f, 0.5f);
        }
    }
}
