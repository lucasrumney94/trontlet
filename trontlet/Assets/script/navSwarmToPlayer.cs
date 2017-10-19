using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navSwarmToPlayer : MonoBehaviour 
{
	public bool enemyActive = false;

	private GameObject player;
	private NavMeshAgent agent;
	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player");
		Invoke("setActive", 1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (enemyActive)
		{
			agent.SetDestination(player.transform.position);
		}
	}

	void setActive()
	{
		enemyActive = true;
	}
}
