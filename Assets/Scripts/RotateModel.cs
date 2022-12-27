using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour
{

    float verticalInput;
    float horizontalInput;
    private float rotationSpeed = 100.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            CamOrbit();
        }

    }

    private void CamOrbit()
    {
        if (Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0)
        {
            verticalInput = Mathf.Clamp(verticalInput, -5, 5);
            verticalInput += Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            horizontalInput = Mathf.Clamp(horizontalInput, -20, 20);
            horizontalInput += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

            transform.localRotation = Quaternion.Euler(verticalInput, -horizontalInput, 1);
        }
    }

}
