using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replaceSelfWithGuncoin : MonoBehaviour {

	public GameObject guncoinPrefab;
	private bool hitFlag = false;

	// Use this for initialization
	void Start () 
	{
		hitFlag = false;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	void OnCollisionEnter(Collision other)
	{

		if (hitFlag == false)
		{
			if (!other.transform.tag.Equals("Player") && !other.transform.tag.Equals("guncoin") || other.transform.tag.Equals("Enemy"))
			{
				Instantiate(guncoinPrefab,other.contacts[0].point, Quaternion.Euler(90,0,0));
				Destroy(gameObject);
				other.gameObject.SendMessage("ApplyDamage", SendMessageOptions.DontRequireReceiver);
				hitFlag = true;
			}
		}
		
	}
}
