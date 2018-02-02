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

	private List<Vector3> directions;
	private List<Vector3> valid_directions;
	private Ray MovementRay;
	private RaycastHit objectHit;

	// Use this for initialization
	void Start () 
	{
		directions = new List<Vector3>();
		directions.Add(new Vector3(gridSize,0,0));
		directions.Add(new Vector3(-gridSize,0,0));
		directions.Add(new Vector3(0,0,gridSize));
		directions.Add(new Vector3(0,0,-gridSize));

		valid_directions = new List<Vector3>();

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
				// Calculate the preferred Square to move to (Towards the Player)
				// If Snake doesn't care or wants to move along X, move along X
				if  ((MovementVector.x==MovementVector.z) || (Mathf.Max(Mathf.Abs(MovementVector.x), Mathf.Abs(MovementVector.z)) == Mathf.Abs(MovementVector.x)))
				{
					MovementVector = new Vector3 (Mathf.Sign(MovementVector.x)*gridSize, 0, 0);
				}
				else 
				{
					MovementVector = new Vector3 (0, 0, Mathf.Sign(MovementVector.z)*gridSize);
				}
				// Is this direction available to move to?
				MovementRay = new Ray(transform.position,MovementVector);
				
				Physics.Raycast(MovementRay, out objectHit, gridSize);
				if (objectHit.collider==null)
				{ 
					// If hit nothing, Move
					transform.position += MovementVector;
				}
				else if(!objectHit.transform.CompareTag("SnakeSegment"))
				{
					// If didn't hit snake segment, Move
					transform.position += MovementVector;
				}
				else
				{
					// Forget previous valid directions
					valid_directions.Clear();
					
					// Find all valid directions
					foreach (Vector3 direction in directions)
					{
						MovementRay = new Ray(transform.position, direction);
						Physics.Raycast(MovementRay, out objectHit, gridSize);
						if (objectHit.collider==null)
						{
							valid_directions.Add(direction);
						}
						else if (!objectHit.transform.CompareTag("SnakeSegment"))
						{
							valid_directions.Add(direction);
						}

					}


					// If no valid direction (must be due to other snake), do not move
					if (valid_directions.Count == 0)
					{
						Debug.Log("Didn't Move!");
						MovementVector = Vector3.zero;
					}
					else 
					{
						// If a valid direction exists, choose a random valid direction
						Debug.Log("Chose a random Direction!");
						Debug.Log(valid_directions.ToString());
						MovementVector = valid_directions[Random.Range(0,valid_directions.Count)];
					}

					// Finally Move along that random valid direction or move 0 if no valid direction exists
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
