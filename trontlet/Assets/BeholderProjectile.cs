using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeholderProjectile : MonoBehaviour {

	public float bulletSpeed = 5.0f;
	public float damage = 5.0f;

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

	void OnTriggerEnter(Collider other)
	{
		if (!other.gameObject.tag.Equals("Enemy") && !other.gameObject.tag.Equals("Room"))
		{
			Destroy(gameObject);
		}
		if (other.gameObject.tag.Equals("Player"))
		{
			other.gameObject.GetComponent<PlayerStats>().Health-=damage;
		}
	}
}
