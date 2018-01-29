using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnakeSegment : MonoBehaviour {

	public float gridSize = 1.25f;
	public float MoveTickTime = 1.0f;
	public SnakeSegment Leader;
	public List<SnakeSegment> FollowingSegments;
	public Vector3 lastPosition;
	public bool head;

	private GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		if (Leader == null)
		{	
			Leader = this.gameObject.GetComponent<SnakeSegment>();
		}
	}
	 
	// Update is called once per frame
	void Update () 
	{
		
	}

	IEnumerator MoveTowardsPlayer()
	{
		lastPosition = transform.position;

		if (Leader == this.gameObject)
		{
			// get player location
			// calculate the move to make
			// make the move

		}
		else
		{
			// get leader location
			// move to where the leader was
			transform.position = Leader.lastPosition;

		}
		yield return new WaitForSeconds(MoveTickTime);
	}
}
