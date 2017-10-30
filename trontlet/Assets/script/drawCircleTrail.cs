using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawCircleTrail : MonoBehaviour {

    public float speed = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.RotateAround(this.transform.parent.transform.position, this.transform.parent.transform.forward, speed);
	}
}
