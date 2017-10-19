using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour {
	public GameObject enemy;
	public int number;

	// Use this for initialization
	void Start () 
	{
		Invoke("spawnEnemyDelay", 2);
		
	}
	
	void spawnEnemyDelay()
	{
		for (int i=0; i<number; i++)
		{
			Instantiate(enemy,transform.position,Quaternion.identity);

		}
	}
}
