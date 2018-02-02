using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnakeSegment : MonoBehaviour {

	public float gridSize = 1.25f;
	public float MoveTickTime = 1.0f;
	public SnakeSegment Leader;
	public List<SnakeSegment> FollowingSegments;
	// public Vector3 lastPosition;

	public bool persist = false;
	public Vector3 persistDirection;
	public int persistDirectionTicks = 4;
	private int persistCounter;

	private GameObject player;

	// Use this for initialization
	void Start () 
	{
		// lastPosition = transform.position;

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

			if (Leader == null)
			{	
				Leader = this.gameObject.GetComponent<SnakeSegment>();
			}

			if (Leader == this.gameObject.GetComponent<SnakeSegment>())
			{
				// get player location
				Vector3 MovementVector = new Vector3 (player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z );
				// Debug.Log(MovementVector);

				//If the distance to the player is smaller than one gridSize, lock in direction for 4 ticks to overshoot 'through' player
				if (MovementVector.sqrMagnitude < Mathf.Pow(gridSize, 2))
				{
					persistDirection = new Vector3 (Mathf.Sign(MovementVector.x)*gridSize, 0, 0);
					persist = true;
				}
				if (persist)
				{
					// If the snake is persisting in a given direction				
					
					transform.position += persistDirection;
					
					persistCounter++;

					if (persistCounter == persistDirectionTicks)
					{
						persistCounter = 0;
						persist = false;
					}
				}
				else
				{
					//The snake is not persisting a direction, and should move toward the player 

					// calculate the move to make
					if (MovementVector.x==MovementVector.z)
					{
						// Debug.Log("Could Move Either Way, Move Along X Axis!");
						MovementVector = new Vector3 (Mathf.Sign(MovementVector.x)*gridSize, 0, 0);
					}
					else if (Mathf.Max(Mathf.Abs(MovementVector.x), Mathf.Abs(MovementVector.z)) == Mathf.Abs(MovementVector.x))
					{
						// Debug.Log("Move Along X Axis!");
						MovementVector = new Vector3 (Mathf.Sign(MovementVector.x)*gridSize, 0, 0);
					}
					else 
					{
						// Debug.Log("Move Along Z Axis!");
						MovementVector = new Vector3 (0, 0, Mathf.Sign(MovementVector.z)*gridSize);
					}

					// make the move
					transform.position += MovementVector;
				}
				
			}
			else
			{
				// get leader location
				// move to where the leader was
				// Debug.Log("Following Leader");
				transform.position = Leader.gameObject.transform.position;

			}
			yield return new WaitForSeconds(MoveTickTime);
		}
	}
}
