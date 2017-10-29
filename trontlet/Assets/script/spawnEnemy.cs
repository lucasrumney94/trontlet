using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour {
	public GameObject enemyPrefab;
	public int number;

	private List<GameObject> Enemies;

	private Vector3 randomPosition;
	private bool triggerOnce = true;
	// Use this for initialization
	void Start () 
	{
		Invoke("spawnEnemyDelay", 2);
		Enemies = new List<GameObject>();
	}
	
	void spawnEnemyDelay()
	{
		for (int i=0; i<number; i++)
		{
			randomPosition.x = Random.Range(0.0f,0.5f);
			randomPosition.y = 0.0f;
			randomPosition.z = Random.Range(0.0f,0.5f);
			GameObject g = Instantiate(enemyPrefab,transform.position+randomPosition,Quaternion.identity) as GameObject;
			
			Enemies.Add(g);

		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals("Player"))
		{
			if (triggerOnce)
			{
				foreach (GameObject enemy in Enemies)
				{
					enemy.GetComponent<navSwarmToPlayer>().enemyActive = true;
				}
				triggerOnce = false;
			}
		}
	}
}
