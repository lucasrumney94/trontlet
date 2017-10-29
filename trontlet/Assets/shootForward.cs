using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootForward : MonoBehaviour {

	public float bulletSpeed = 5.0f;

	private Rigidbody rb;
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		rb.AddForce(0.0f,0.0f,bulletSpeed);
	}
}
