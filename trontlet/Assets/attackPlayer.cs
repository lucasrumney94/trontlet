using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackPlayer : MonoBehaviour {


    public float speed = 5.0f;
    public float turnForce = 5.0f;
    public float rollForce = 5.0f;
    public float swayAmount = 2.0f;
    public float swaySpeed = 2.0f;

    private Activation activation;
    private Rigidbody rb;
    private GameObject player;

	// Use this for initialization
	void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        activation = gameObject.GetComponent<Activation>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (activation.activated)
        {
            rb.AddTorque(turnForce * Vector3.Cross(transform.forward, rb.velocity));
            rb.AddTorque(rollForce * Vector3.Cross(transform.up, Vector3.up));

            rb.AddForce(speed * (player.transform.position - transform.position).normalized);
            rb.AddRelativeForce(swayAmount * Vector3.right * Mathf.Cos(swaySpeed * Time.time));

        }
	}
}
