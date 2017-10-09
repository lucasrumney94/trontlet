using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class waitThenBake : MonoBehaviour {
			
	void Start()
	{
		Invoke("buildMesh", 2);
	}
	
	void buildMesh()
	{
		gameObject.GetComponent<NavMeshSurface>().BuildNavMesh();

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
