using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallKiller : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.name == "North" || other.gameObject.name == "South" || other.gameObject.name == "East" || other.gameObject.name == "West")
		{
			Destroy(other.gameObject);
		}
	}

}
