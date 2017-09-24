using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 10.0f;

    // For Movement
    private float forward;
    private float right;
    private Rigidbody rb;
    private Vector3 forceVector;

    // For MouseLook
    public Camera myCamera;
    public float mouseSensitivity = 100.0f;
    public float mouseClampAngle = 80.0f;
    private float mouseX;
    private float mouseY;
    private float rotX;
    private float rotY;



    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

void FixedUpdate()
    {
        movement();
        mouseLook();
        cursorLockState();
    }


    void movement()
    {
        forward = Input.GetAxis("Vertical");
        right = Input.GetAxis("Horizontal");

        forceVector.x = right*speed;
        forceVector.y = 0.0f;
        forceVector.z = forward*speed;
        rb.AddRelativeForce(forceVector);

    }

    void mouseLook()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0.0f, rotY, 0.0f);

        rotX = Mathf.Clamp(rotX, -mouseClampAngle, mouseClampAngle);
        myCamera.transform.localRotation = Quaternion.Euler(rotX, 0.0f, 0.0f);
        
    }

    void cursorLockState()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
