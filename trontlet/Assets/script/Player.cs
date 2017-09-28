using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int guncoins = 10; 

    public float force = 10.0f;
    public float maxSpeed = 20.0f;
    public float translateSpeed = 1.0f;

    // For Movement
    private float forward;
    private float right;
    private Rigidbody rb;
    private Vector3 forceVector;
    private Vector3 translateVector;

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
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        originalRotation = transform.localRotation;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void FixedUpdate()
    {
        translationalMovement();
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

    void rigidBodyMovement()
    {
        forward = Input.GetAxis("Vertical");
        right = Input.GetAxis("Horizontal");

        forceVector.x = right * force;
        forceVector.y = 0.0f;
        forceVector.z = forward * force;
        rb.AddRelativeForce(forceVector);

        // Debug.Log(rb.velocity.magnitude);
        if (rb.velocity.sqrMagnitude > Mathf.Pow(maxSpeed,2))
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }

    void translationalMovement()
    {
        forward = Input.GetAxis("Vertical");
        right = Input.GetAxis("Horizontal");

        translateVector.z = forward * translateSpeed * Time.deltaTime;
        translateVector.x = right * translateSpeed * Time.deltaTime;

        transform.Translate(translateVector);

    }

    void mouseLook()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

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
