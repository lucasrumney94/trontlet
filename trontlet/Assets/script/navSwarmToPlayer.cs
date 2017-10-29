﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navSwarmToPlayer : MonoBehaviour 
{
	public bool enemyActive = false;

	private GameObject player;
	private NavMeshAgent agent;

	private float randomDuration;
	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player");
		Invoke("setActive", 1);
		StartCoroutine("NavigateToPlayer");
		randomDuration = Random.Range(0.1f,3.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void setActive()
	{
		enemyActive = true;
	}
	IEnumerator NavigateToPlayer()
	{
		for(;;)
		{
			if (enemyActive)
			{
				agent.SetDestination(player.transform.position);
			}
			yield return new WaitForSeconds(randomDuration);

		}

	}

}
