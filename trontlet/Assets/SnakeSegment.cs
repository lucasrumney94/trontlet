using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnakeSegment : MonoBehaviour {

	public float gridSize = 1.25f;
	public float MoveTickTime = 1.0f;
	public SnakeSegment Leader;
	public List<SnakeSegment> FollowingSegments;
	public Vector3 lastPosition;
	

	private GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		if (Leader == null)
		{	
			Leader = this.gameObject.GetComponent<SnakeSegment>();
		}
		StartCoroutine("MoveTowardsPlayer");
	}
	 
	// Update is called once per frame
	void Update () 
	{
		
	}

	IEnumerator MoveTowardsPlayer()
	{
		for (;;)
		{
			//Debug.Log("SSSSSSSSS!");
			lastPosition = transform.position;
			if (Leader == null)
			{	
				Leader = this.gameObject.GetComponent<SnakeSegment>();
			}


			if (Leader == this.gameObject.GetComponent<SnakeSegment>())
			{
				// get player location
				Vector3 MovementVector = new Vector3 (player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z );
				Debug.Log(MovementVector);

				// calculate the move to make
				if (MovementVector.x==MovementVector.z)
				{
					MovementVector = new Vector3 (Mathf.Sign(MovementVector.x)*gridSize, 0, 0);
				}
				else if (Mathf.Max(MovementVector.x, MovementVector.z) == MovementVector.x)
				{
					MovementVector = new Vector3 (Mathf.Sign(MovementVector.x)*gridSize, 0, 0);
				}
				else 
				{
					MovementVector = new Vector3 (0, 0, Mathf.Sign(MovementVector.z)*gridSize);
				}

				// make the move
				transform.position += MovementVector;
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
}
