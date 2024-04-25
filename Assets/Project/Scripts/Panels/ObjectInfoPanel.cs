using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Include the TextMeshPro namespace

public class ObjectInfoPanel : MonoBehaviour
{
    // TMP Text field for displaying the description
    public TMP_Text descriptionText;

    // Start is called before the first frame update
    void Start()
    {
        // Optionally initialize the descriptionText with some default text
        if (descriptionText != null)
            descriptionText.text = "Initial description or instructions.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to set the text of the description field
    public void SetDescription(string description)
    {
        if (descriptionText != null)
            descriptionText.text = description;
        else
            Debug.LogError("Description Text component not set on " + gameObject.name);
    }
}
