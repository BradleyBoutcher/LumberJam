﻿using UnityEngine;

public class SimpleCameraController : MonoBehaviour
{
    //The camera's transform to save space
    Transform cameraTrans;

    void Start()
    {
        //Get the camera's transform
        cameraTrans = Camera.main.transform;

        //Move the camera to the start position
        cameraTrans.position = Vector3.zero;

        //Rotate the camera to the correct rotation
        cameraTrans.eulerAngles = new Vector3(45f, 360f, 0f);

        //Zoom the camera to the initial zoom
        cameraTrans.Translate(-Vector3.forward * 10.00f);
    }
}