using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    public MapGenerator mapGen;

    [SerializeField]
    public float distanceFromTarget = 800.0f;
    [SerializeField]
    public float mouseSensitivity = 5f;
    [SerializeField]
    public float scrollingSpeed = 500f;
    [SerializeField]
    public float rotationSmoothTime = 60f;
    [SerializeField]
    public float distanceLerpTime = 10f;
    [SerializeField]
    public float angleOfView = 40f;

    private Vector3 currentRotation;
    private Vector3 smoothVelocity = Vector3.zero;

    private float rotationY;
    private float rotationX;

    private float distanceDelta;

    void Start()
    {
        mapGen.GenerateMap();

        // Set beginning position of camera (it will be rotated later)
        rotationY = 0;
        rotationX = angleOfView;

        currentRotation = new Vector3(angleOfView, 0);

        distanceDelta = distanceFromTarget;
    }

    private bool isMousePressed = false;
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            distanceDelta = distanceFromTarget - Input.GetAxis("Mouse ScrollWheel") * scrollingSpeed;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMousePressed = false;
        }
        else if (Input.GetMouseButtonDown(0) || isMousePressed)
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
        transform.position = target.position - transform.forward * distanceFromTarget;

        // Lineary interpolate distance from target
        distanceFromTarget = Mathf.Lerp(distanceFromTarget, distanceDelta, Time.deltaTime*distanceLerpTime);
    }
}