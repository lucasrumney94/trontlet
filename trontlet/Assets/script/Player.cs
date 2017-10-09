using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int guncoins = 10; 
    public float speed = 1.0f;
    public float gravity = 9.8f;

    // For Movement
    private CharacterController controller;
    private float forward;
    private float right;
    private Vector3 translateVector;
    private Vector3 moveDirection;

    // For MouseLook
    public Camera myCamera;
    public float mouseSensitivity = 100.0f;
    public float mouseClampAngle = 80.0f;



    private float mouseX;
    private float mouseY;
    private float rotX;
    private float rotY;
    private Quaternion originalRotation;


    // Use this for initialization
    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        originalRotation = transform.localRotation;
        controller = GetComponent<CharacterController>();
    }
	
    void FixedUpdate()
    {
        //translationalMovement();
    }

    void Update()
    {
        controllerMovement();
        mouseLook();
        cursorLockState();
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "guncoin")
        {
            Destroy(other.gameObject);
            guncoins++;
            //trigger coin sound
        }
    }
    void OnCollisionStay(Collision other)
    {
        if(other.transform.tag == "guncoin")
        {
            Destroy(other.gameObject);
            guncoins++;
            //trigger coin sound
        }
    }


/*     void translationalMovement()
    {
        forward = Input.GetAxis("Vertical");
        right = Input.GetAxis("Horizontal");

        translateVector.z = forward * translateSpeed * Time.deltaTime;
        translateVector.x = right * translateSpeed * Time.deltaTime;

        transform.Translate(translateVector);

    } */

    void controllerMovement()
    {
        if (controller.isGrounded) 
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;            
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }


    void mouseLook()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity;
        rotX += mouseY * mouseSensitivity;

        transform.rotation = originalRotation*Quaternion.Euler(0.0f, rotY, 0.0f);

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
