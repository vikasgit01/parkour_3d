using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is attached to Main Camera/Player Camera
public class Camera_Controller : MonoBehaviour
{

    [SerializeField] private float sensitivity=3f;
    [SerializeField] private Transform player;
    [SerializeField] private Vector2 minMaxUPDown;
   
    private float rotationUpDown;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //Get Input values of x and y mouse axis
        float xAxis = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float yAxis = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        //rotate camera up and down
        rotationUpDown -= yAxis;
        rotationUpDown = Mathf.Clamp(rotationUpDown, minMaxUPDown.x, minMaxUPDown.y);
        transform.localRotation = Quaternion.Euler(rotationUpDown, 0f, 0f);

        //rotate player body left and right
        player.Rotate(Vector3.up * xAxis);

    }

}
