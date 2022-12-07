/*
 *  This code is executed only at the runtime.
 *  It's purpose is to get input from mouse and rotate camera in accordance.
*/
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Transform target;

    public float currentDistance = 800.0f;
    public float angleOfView = 50f;

    // Mouse controls
    public float mouseSensitivity = 5f;
    public float scrollingSpeed = 500f;

    // Parameters for smoothly changing camera rotation/zoom
    public float rotationSmoothTime = 60f;
    public float distanceLerpTime = 10f;

    private Vector3 currentRotation;
    private Vector3 smoothVelocity = Vector3.zero;

    private float nextDistance;

    private float rotationY;
    private float rotationX;

    private bool isMousePressed = false;

    public void changeMouseSensitivity(string newMouseSensitivity)
    {
        if (newMouseSensitivity != "")
        {
            mouseSensitivity = float.Parse(newMouseSensitivity);
            if (mouseSensitivity > 99) mouseSensitivity = 99;
            if (mouseSensitivity < 0) mouseSensitivity = 0;
        }
    }

    public void changeScrollingSpeed(string newScrollingSpeed)
    {
        if (newScrollingSpeed != "")
        {
            scrollingSpeed = float.Parse(newScrollingSpeed);
            if (scrollingSpeed > 9999) scrollingSpeed = 9999;
            if (scrollingSpeed < 0) scrollingSpeed = 0;
        }
    }

    public void changeAngleOfView(string newAngleOfView)
    {
        if (newAngleOfView != "")
        {
            rotationX = float.Parse(newAngleOfView);
            if (rotationX > 360) rotationX = 360;
            if (rotationX < 0) rotationX = 0;
        }
    }

    public void changeCurrentDistance(string newCurrentDistance)
    {
        if (newCurrentDistance != "")
        {
            nextDistance = float.Parse(newCurrentDistance);
            if (nextDistance > 9999) nextDistance = 9999;
            if (nextDistance < 0) nextDistance = 0;
        }
    }

    public void changeRotationSmoothTime(string newRotationSmoothTime)
    {
        if (newRotationSmoothTime != "")
        {
            rotationSmoothTime = float.Parse(newRotationSmoothTime);
            if (rotationSmoothTime > 999) rotationSmoothTime = 999;
            if (rotationSmoothTime < 0) rotationSmoothTime = 0;
        }
    }

    public void changeDistanceLerpTime(string newDistanceLerpTime)
    {
        if (newDistanceLerpTime != "")
        {
            distanceLerpTime = float.Parse(newDistanceLerpTime);
            if (distanceLerpTime > 99) distanceLerpTime = 99;
            if (distanceLerpTime < 0) distanceLerpTime = 0;
        }
    }
    

    void Start()
    {
        rotationY = 0;
        rotationX = angleOfView;

        // Set beginning rotation of camera
        currentRotation = new Vector3(rotationX, rotationY);

        nextDistance = currentDistance;
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            nextDistance = currentDistance - Input.GetAxis("Mouse ScrollWheel") * scrollingSpeed;
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
                mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
            }
            else
            {
                mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
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