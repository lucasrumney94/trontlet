using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeholderProjectile : MonoBehaviour {

	public float bulletSpeed = 5.0f;

	private Rigidbody rb;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void FixedUpdate () 
	{
		rb.AddRelativeForce(0.0f, 0.0f, bulletSpeed);
	}

	void OnCollisionEnter(Collision other)
	{
		if (!other.gameObject.tag.Equals("Enemy"))
		{
			Destroy(gameObject);
		}
	}
}
