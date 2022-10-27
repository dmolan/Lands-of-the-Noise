using System.Collections;
using System.Collections.Generic;
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

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            rotationY += mouseX;
            rotationX = angleOfView;
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