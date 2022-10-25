using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField]
    private float _mouseSensitivity = 7f;

    private float _rotationY;
    private float _rotationX;

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _distanceFromTarget = 800.0f;

    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity = Vector3.zero;

    [SerializeField]
    private float _smoothTime = 0.2f;

    //[SerializeField]
    //private Vector2 _rotationXMinMax = new Vector2(-40, 40);

    public MapGenerator mapGen;

    void Start()
    {
        mapGen.GenerateMap();

        _rotationY = 0;
        _rotationX = 30;

        Vector3 nextRotation = new Vector3(_rotationX, _rotationY);

        // Apply damping between rotation changes
        // _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
        transform.localEulerAngles = nextRotation;

        // Substract forward vector of the GameObject to point its forward vector to the target
        transform.position = _target.position - transform.forward * _distanceFromTarget;
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

            float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
            //float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

            _rotationY += mouseX;
            _rotationX = 30;
        }

            // Apply clamping for x rotation 
            //_rotationX = Mathf.Clamp(_rotationX, _rotationXMinMax.x, _rotationXMinMax.y);

            Vector3 nextRotation = new Vector3(_rotationX, _rotationY);

            // Apply damping between rotation changes
            _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
            transform.localEulerAngles = _currentRotation;

            // Substract forward vector of the GameObject to point its forward vector to the target
            transform.position = _target.position - transform.forward * _distanceFromTarget;
        
    }
}