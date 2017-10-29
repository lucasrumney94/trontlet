using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beholder : MonoBehaviour {
	public float health = 5.0f;
	public int droppedGuncoins = 6;
	public float shootDelay = 3.0f;
	public GameObject guncoinPrefab;
	public GameObject beholderProjectilePrefab;


	// Use this for initialization
	void Start () 
	{
		StartCoroutine("Shoot");		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void ApplyDamage()
	{
		health--;
		if (health<=0)
		{
			for (int i = 0; i<droppedGuncoins; i++)
			{
				Instantiate(guncoinPrefab, transform.position, Quaternion.Euler(90,0,0));
			}
			Destroy(gameObject);
		}

	}

	IEnumerator Shoot()
	{
		for (;;)
		{
			Instantiate(beholderProjectilePrefab, transform.position, transform.rotation);
			yield return new WaitForSeconds(shootDelay);
		}
	}
}
