using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour {

	public Transform gunEnd;
	public GameObject firingGuncoinPrefab;
	public float bulletForce =5.0f;
	public float fireRate;
	public float recoilForce;

	private GameObject bullet;
	private float nextFire;

	private Player player;
	private Rigidbody playerRb;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		playerRb = player.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire && player.guncoins>0) 
		{
			nextFire = Time.time + fireRate;
			player.guncoins--;

			bullet=Instantiate(firingGuncoinPrefab, gunEnd.position, gunEnd.rotation) as GameObject;
			bullet.GetComponent<Rigidbody>().AddForce(transform.forward*bulletForce,ForceMode.Impulse);
			
			playerRb.AddForce(-gunEnd.forward*recoilForce,ForceMode.Impulse);
		}
	}
}
