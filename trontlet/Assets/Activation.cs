using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour {

    public bool activated = false;
    public float activationRange = 100.0f;

    private GameObject player;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    // Update is called once per frame

    //TODO: This only needs to be check every few seconds and not every frame. 
    void Update ()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < activationRange)
        {
            activated = true;
        }
        else
        {
            Debug.Log(Vector3.Distance(transform.position, player.transform.position));
            activated = false;
        }
	}
}
