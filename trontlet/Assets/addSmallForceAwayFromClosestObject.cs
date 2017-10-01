using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addSmallForceAwayFromClosestObject : MonoBehaviour {
	public float plinkForce;
	public float plinkUpForce;

	// Use this for initialization
	void Start () 
	{
		Vector3 myPlinkDirection = Random.insideUnitSphere*plinkForce;
		myPlinkDirection.y = plinkUpForce;
        gameObject.GetComponent<Rigidbody>().AddForce(myPlinkDirection, ForceMode.Impulse);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
