using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addSmallForceTowardsPlayer : MonoBehaviour {
	public float forceMagnitude;

	private GameObject Player;
	private RaycastHit hit;
	private Rigidbody rb;
	private Vector3 toPlayer;
	public Vector3 forceToPlayer;
	private int layerMask;

	// Use this for initialization
	void Start () 
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		rb=GetComponent<Rigidbody>();
		layerMask = 1 << 9;
		layerMask = ~layerMask;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

		toPlayer =  (Player.transform.position-transform.position);
		forceToPlayer = toPlayer;
		forceToPlayer.y = 0.0f;
		forceToPlayer = forceToPlayer.normalized;
		//Debug.DrawRay(transform.position,toPlayer,Color.red, 500.0f);
		if (Physics.Raycast(transform.position, toPlayer, out hit, 6.0f, layerMask, QueryTriggerInteraction.Ignore))
		{
			if (hit.transform.gameObject.tag.Equals("Player"))
			{
				rb.AddForce(forceToPlayer*forceMagnitude);
			}
		}
	}

}
