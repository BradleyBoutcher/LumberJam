using System.Collections;
using UnityEngine;

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

    void Update()
    {
        float ScrollWheelChange = Input.GetAxis("Mouse ScrollWheel");
        if (!GameBoardUtilities.FloatIsZero(ScrollWheelChange))
        {
            UpdateZoom(ScrollWheelChange);
        }
    }

    private void UpdateZoom(float ScrollWheelChange)
    {
        try
        {
            float R = ScrollWheelChange * 10.0f;                            // radius from current camera position

            R = R > 2.0f ? 2.0f : R;                                        // Limit zoom amount
            R = R < -2.0f ? -2.0f : R;

            float posX = Camera.main.transform.eulerAngles.x + 90;          // get up down

            float posY = -1 * (Camera.main.transform.eulerAngles.y - 90);   // get left right

            posX = posX * Mathf.Deg2Rad;                                    // convert from degrees to radians
            posY = posY * Mathf.Deg2Rad;

            float camX = Camera.main.transform.position.x;                  //Get current camera postition for the offset
            float camY = Camera.main.transform.position.y;
            float camZ = Camera.main.transform.position.z;

            if ((camY > 3.0f && ScrollWheelChange > 0) || (camY < 10.0f && ScrollWheelChange < 0))
            {
                float X = R * Mathf.Sin(posX) * Mathf.Cos(posY);                // Calculate new camera position
                float Z = R * Mathf.Sin(posX) * Mathf.Sin(posY);
                float Y = R * Mathf.Cos(posX);

                Camera.main.transform.position = new Vector3(camX + X, camY + Y, camZ + Z); // Move the camera!
            }

        }
        catch
        {
            Debug.Log("Unable to Zoom in or Out");
        }
    }
}