using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float meleeDamageDistance = 1.0f;
	public float damage = 1.0f;
	public float hitDelay = 2.0f;

	[Range(0.01f,2f)]
	public float hitRandomRange;
	private GameObject Player;

	// Use this for initialization
	void Start () 
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		hitRandomRange = Random.Range(0.0f,hitRandomRange);
		StartCoroutine("MeleeAttackPlayer");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void ApplyDamage()
	{
		Destroy(gameObject);
	}

	IEnumerator MeleeAttackPlayer()
	{
		
		for (;;)
		{
			if (Vector3.SqrMagnitude(Player.transform.position-transform.position)<= meleeDamageDistance*meleeDamageDistance)
			{
				Player.GetComponent<PlayerStats>().Health-=damage;
			}
			yield return new WaitForSeconds(hitDelay+hitRandomRange);
		}
	}
}
