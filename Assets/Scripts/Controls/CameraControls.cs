/*
 *  This code is executed only at the runtime.
 *  It's purpose is to get input from mouse and rotate camera in accordance.
*/
using UnityEngine;
using TMPro;

public class CameraControls : MonoBehaviour
{
    public Transform target;

    public float currentDistance;
    public float defaultDistance = 800f;
    public float angleOfView;
    public float deafultAngleOfView = 50f;

    // Mouse controls
    public float rotationSensitivity = 5f;
    public float zoomingSpeed = 500f;

    // Parameters for smoothly changing camera rotation/zoom
    public float rotationSmoothTime = 60f;
    public float distanceLerpTime = 10f;

    public Vector3 currentRotation;
    private Vector3 smoothVelocity = Vector3.zero;

    public float nextDistance;

    public float rotationY;
    public float rotationX;

    private bool isMousePressed = false;

    public TMP_InputField inputRotationSensitivity, inputZoomingSpeed, inputAngleOfView, 
        inputCurrentDistance, InputRotationSmoothTime, inputDistanceLerpTime;



    public void changeMouseSensitivity(string newMouseSensitivity)
    {
        if (newMouseSensitivity != "")
        {
            rotationSensitivity = float.Parse(newMouseSensitivity);
            if (rotationSensitivity > 99) 
            {
                rotationSensitivity = 99;
                inputRotationSensitivity.text = "99";
            }
            if (rotationSensitivity < 0) 
            {
                rotationSensitivity = 0;
                inputRotationSensitivity.text = "0";
            }
        }
    }

    public void changeScrollingSpeed(string newScrollingSpeed)
    {
        if (newScrollingSpeed != "")
        {
            zoomingSpeed = float.Parse(newScrollingSpeed);
            if (zoomingSpeed > 9999) 
            {
                zoomingSpeed = 9999;
                inputZoomingSpeed.text = "9999";
            }
            if (zoomingSpeed < 0) 
            {
                zoomingSpeed = 0;
                inputZoomingSpeed.text = "0";
            }
        }
    }

    public void changeAngleOfView(string newAngleOfView)
    {
        if (newAngleOfView != "")
        {
            deafultAngleOfView = float.Parse(newAngleOfView);
            rotationX = float.Parse(newAngleOfView);
            if (rotationX > 90) 
            {
                rotationX = 90;
                inputAngleOfView.text = "90";
            }
            if (rotationX < 10) 
            {
                rotationX = 0;
                inputAngleOfView.text = "0";
            }
        }
    }

    public void changeCurrentDistance(string newCurrentDistance)
    {
        if (newCurrentDistance != "")
        {
            defaultDistance = float.Parse(newCurrentDistance);
            nextDistance = float.Parse(newCurrentDistance);
            if (nextDistance > 9999) 
            {
                nextDistance = 9999;
                inputCurrentDistance.text = "9999";
            }
            if (nextDistance < 0) 
            {
                nextDistance = 0;
                inputCurrentDistance.text = "0";
            }
        }
    }

    public void changeRotationSmoothTime(string newRotationSmoothTime)
    {
        if (newRotationSmoothTime != "")
        {
            rotationSmoothTime = float.Parse(newRotationSmoothTime);
            if (rotationSmoothTime > 999) 
            {
                rotationSmoothTime = 999;
                InputRotationSmoothTime.text = "999";
            }
            if (rotationSmoothTime < 0) 
            {
                rotationSmoothTime = 0;
                InputRotationSmoothTime.text = "0";
            }
        }
    }

    public void changeDistanceLerpTime(string newDistanceLerpTime)
    {
        if (newDistanceLerpTime != "")
        {
            distanceLerpTime = float.Parse(newDistanceLerpTime);
            if (distanceLerpTime > 99) 
            {
                distanceLerpTime = 99;
                inputDistanceLerpTime.text = "99";
            }
            if (distanceLerpTime < 0)
            {
                distanceLerpTime = 0;
                inputDistanceLerpTime.text = "0";
            }
        }
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            nextDistance = currentDistance - Input.GetAxis("Mouse ScrollWheel") * zoomingSpeed;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isMousePressed = false;
        }
        else if (Input.GetMouseButtonDown(1) || isMousePressed)
        {
            isMousePressed = true;

            float mouseX = 0, mouseY = 0;
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            {
                mouseY = Input.GetAxis("Mouse Y") * rotationSensitivity;
            }
            else
            {
                mouseX = Input.GetAxis("Mouse X") * rotationSensitivity;
            }

            rotationY += mouseX;
            rotationX += mouseY;
            if (rotationX < 10) rotationX = 10;
            if (rotationX > 90) rotationX = 90;
        }

        Vector3 nextRotation = new Vector3(rotationX, rotationY);

        // Apply damping between rotation changes
        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, Time.deltaTime * rotationSmoothTime);
        transform.localEulerAngles = currentRotation;

        // Substract forward vector of the GameObject to point its forward vector to the target
        transform.position = target.position - transform.forward * currentDistance;

        // Lineary interpolate distance from target
        if (nextDistance > 0)
        {
            currentDistance = Mathf.Lerp(currentDistance, nextDistance, Time.deltaTime*distanceLerpTime);
        }
    }
}
