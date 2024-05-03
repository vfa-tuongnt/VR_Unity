using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    Transform mainCamera;

    void Awake()
    {
        mainCamera = Camera.main.transform;                
    }

    void Update()
    {
        Vector3 dir = this.transform.position - mainCamera.position;
        this.transform.LookAt(this.transform.position + dir);
    }
}
