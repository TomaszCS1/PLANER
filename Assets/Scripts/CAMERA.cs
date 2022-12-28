using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMERA : MonoBehaviour
{
    private Vector3 StartMousePosition;
    private float zoomScale = 10.0f;
    private float zoomMin = 0.1f;
    private float zoomMax = 10.0f;

    float verticalInput;
    float horizontalInput;
    private float rotationSpeed = 100.0f;
    private float panSpeed = 100.00f;


    public Vector2 turn;
    public Vector3 move;


    float MouseSensivity = 1f;

    [SerializeField] private Camera mainCamera;


    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetMouseButton(0))                            //LOCAL ROTATION CAMERA
        //{
        //    turn.x = Mathf.Clamp(turn.x, -20, 20);
        //    turn.x += Input.GetAxis("Mouse X");

        //    turn.y = Mathf.Clamp(turn.y, -5, 5);
        //    turn.y += Input.GetAxis("Mouse Y");

        //    transform.localRotation = Quaternion.Euler(turn.y, -turn.x, 0);

        //}

        //if (Input.GetMouseButton(1))
        //{
        //    1.
        //    move.x += Input.GetAxis("Mouse X") * rotationSpeed;
        //    move.y += Input.GetAxis("Mouse Y") * rotationSpeed;
        //    transform.position += new Vector3(-move.x, -move.y, 0);


        //    2.
        //    Vector3 move = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    transform.position += new Vector3(-move.x, move.y, 0) * Time.deltaTime;
        //    }


        //3.
        if (Input.GetMouseButton(0))
        {
            CamOrbit();
        }

        if (Input.GetMouseButton(1))
        {
            Pan();
        }


        Zoom(Input.GetAxis("Mouse ScrollWheel"));

    }

    private void CamOrbit()
    {
        if (Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0)
        {
            verticalInput = Mathf.Clamp(verticalInput, -5, 5);
            verticalInput += Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            horizontalInput = Mathf.Clamp(horizontalInput, -20, 20);
            horizontalInput += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

            transform.localRotation = Quaternion.Euler(verticalInput, -horizontalInput, 0);

        }
    }




    private void Pan()
    {
        // save initial position of mouse whenn RMB pressed for first time
        if (Input.GetMouseButtonDown(1))
        {
            StartMousePosition = Input.mousePosition;

        }

        if (Input.GetMouseButton(1))
        {
            var newMousePosition = Input.mousePosition;

        // calculate distance between previous mouse position and current mouse position

            move = StartMousePosition - newMousePosition;
         

            //Debug.Log("start pos = " + StartMousePosition + " new position = " + newMousePosition + " move X = " + move.x);

            transform.position += new Vector3(move.x *panSpeed *Time.deltaTime, move.y * panSpeed *Time.deltaTime, 0);

        // set current position as new to prevent smooth movement
            StartMousePosition = newMousePosition;
        }
    }






    //// save initial position of mouse whenn RMB pressed for first time
    //if(Input.GetMouseButtonDown(1))
    //{
    //    mouseWorldPosStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //}

    //// calculate distance between initial mouse position and current mouse position
    //if (Input.GetMouseButton(1))
    //{
    //    mouseWorldPosStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    var newMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //    Vector3 mouseWorldPosDiff = mouseWorldPosStart - newMousePosition;

    //    Debug.Log( "Initial position: " + mouseWorldPosStart + " Delta = " + mouseWorldPosDiff + " New Position: " + newMousePosition );

    //    //move the camere by the distance
    //    transform.position += mouseWorldPosDiff;
    //}


    private void Zoom(float zoomDiff)
    {
        if (zoomDiff != 0)
        {
            StartMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - zoomDiff * zoomScale, zoomMin, zoomMax);
            Vector3 mouseWorldPosDiff = StartMousePosition - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += mouseWorldPosDiff;
        }
    }

}