using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    public MapGenerator mapGen;

    [SerializeField]
    private float distanceFromTarget = 800.0f;
    [SerializeField]
    private float mouseSensitivity = 7f;
    [SerializeField]
    private float smoothTime = 0.2f;

    private Vector3 currentRotation;
    private Vector3 smoothVelocity = Vector3.zero;

    private float rotationY;
    private float rotationX;

    void Start()
    {
        mapGen.GenerateMap();

        // Set beginning position of camera (it will be rotated later)
        rotationY = 0;
        rotationX = 30;
    }

    private bool isMousePressed = false;
    void Update()
    {
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
            rotationX = 30;
        }

        Vector3 nextRotation = new Vector3(rotationX, rotationY);

        // Apply damping between rotation changes
        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);
        transform.localEulerAngles = currentRotation;

        // Substract forward vector of the GameObject to point its forward vector to the target
        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}