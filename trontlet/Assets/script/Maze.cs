using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour {

	public GameObject CellPrefab;
	public GameObject RoomPrefab;
	public GameObject MazeExitPrefab;
	public int Level;
	public int width;
	public int length;
	public int numberOfRooms;
	
	private Vector3 cellSpawnPosition;

	
	private Cell[,] Cells;
	private Stack<Cell> stack;

	private bool generatingMaze;
	// Use this for initialization
	void Start () 
	{
		// Initialize Values for Maze Generation
		stack = new Stack<Cell>();
		generatingMaze = true;

		// Generate a new 2 dimensional array of Cells
		Cells = new Cell[width,length];

		//Populate the array with Spawned Cells
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < length; j++)
			{
				cellSpawnPosition.y = CellPrefab.transform.localScale.y/2;
				cellSpawnPosition.x = i*CellPrefab.transform.localScale.x;
				cellSpawnPosition.z = j*CellPrefab.transform.localScale.z;

				GameObject temp = Instantiate(CellPrefab, cellSpawnPosition, Quaternion.identity) as GameObject;
				temp.transform.parent = transform;
				temp.name = "Cell X: " + i.ToString() + " Z: " + j.ToString();
				Cells[i,j] = temp.GetComponent<Cell>();
				Cells[i,j].xCoord = i;
				Cells[i,j].zCoord = j;
			}
		}

		//Choose a random starting Cell
		Cell startCell = Cells[Random.Range(0,width-1),Random.Range(0,length-1)];
		startCell.visited = true;
		stack.Push(startCell);


		while (generatingMaze)
		{
			// Choose Random Neighboring Cell of the top of the stack cell
			Cell myNextCell = findRandomUnvisitedNeighbors(stack.Peek());
			if (myNextCell != null)
			{
				//Find the walls between the current and next cell and delete them
				//North
				if(myNextCell.zCoord-stack.Peek().zCoord == 1)
				{
					GameObject.Destroy(stack.Peek().North);
					GameObject.Destroy(myNextCell.South);
				}
				//South
				if(myNextCell.zCoord-stack.Peek().zCoord == -1)
				{
					GameObject.Destroy(stack.Peek().South);
					GameObject.Destroy(myNextCell.North);
				}
				//East
				if(myNextCell.xCoord-stack.Peek().xCoord == 1)
				{
					GameObject.Destroy(stack.Peek().East);
					GameObject.Destroy(myNextCell.West);
				}
				//West
				if(myNextCell.xCoord-stack.Peek().xCoord == -1)
				{
					GameObject.Destroy(stack.Peek().West);
					GameObject.Destroy(myNextCell.East);
				}

				// mark the next cell as visited
				myNextCell.visited = true;
				stack.Push(myNextCell);
			}
			else
			{
				// ELSE POP until valid neighbor is found
				stack.Pop();
				if (stack.Count == 0)
				{
					generatingMaze = false;
				}
			}
		}

		int roomMargin = (int)RoomPrefab.transform.localScale.x/(int)CellPrefab.transform.localScale.x;
		roomMargin += 1;
		// Now Generate the Rooms by deleting walls
		for (int k = 0; k<numberOfRooms; k++)
		{
			
			
			Cell roomCenterCell = Cells[Random.Range(roomMargin,width-roomMargin),Random.Range(roomMargin,length-roomMargin)];
			GameObject tempRoom = Instantiate(RoomPrefab, roomCenterCell.transform.position, Quaternion.identity) as GameObject;
			tempRoom.transform.parent = transform;
		}

		// Now Choose an Exit Cell and Remove the Floor
		Cell exitCell = Cells[width-Random.Range(roomMargin,roomMargin+3),length-Random.Range(roomMargin,roomMargin+3)];
		GameObject myExitPlilar = Instantiate(MazeExitPrefab,exitCell.gameObject.transform.position,Quaternion.identity) as GameObject;
		//myExitPlilar.transform.parent = transform;
		GameObject.Destroy(exitCell.gameObject);


		// Now Close up the boundary


	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	Cell findRandomUnvisitedNeighbors(Cell currentCell)
	{

		List<Cell> validCells = new List<Cell>();
		
		// find valid neighbors
		// check North
		if (currentCell.zCoord < length-1)
		{
			if (Cells[currentCell.xCoord, currentCell.zCoord+1].visited == false)
			{
				validCells.Add(Cells[currentCell.xCoord,currentCell.zCoord+1]);
			}
		}

		//check South
		if (currentCell.zCoord > 0)
		{
			if (Cells[currentCell.xCoord,currentCell.zCoord-1].visited == false)
			{
				validCells.Add(Cells[currentCell.xCoord,currentCell.zCoord-1]);
			}
		}
		
		//check East
		if (currentCell.xCoord < width-1)
		{
			if (Cells[currentCell.xCoord+1,currentCell.zCoord].visited == false)
			{
				validCells.Add(Cells[currentCell.xCoord+1,currentCell.zCoord]);
			}
		}

		//check West
		if (currentCell.xCoord > 0)
		{
			if (Cells[currentCell.xCoord-1,currentCell.zCoord].visited == false)
			{
				validCells.Add(Cells[currentCell.xCoord-1,currentCell.zCoord]);
			}
		}
		
		// return a random valid neighbor if there is one
		if (validCells.Count > 0)
		{
			Cell nextCell = validCells[Random.Range(0,validCells.Count)];
			return nextCell;
		}
		else 
		{
			return null;
		}
	}
}
