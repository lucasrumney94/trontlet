using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float Health = 57.0f;
    public float MaxHealth = 100.0f;



	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Health = Mathf.Clamp(Health, 0.0f, MaxHealth);
	}
}
