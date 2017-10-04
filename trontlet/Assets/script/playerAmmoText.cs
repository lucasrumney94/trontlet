using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerAmmoText : MonoBehaviour {

	private Player myPlayer;
	private Text myText;
	// Use this for initialization
	void Start () 
	{
		myPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		myText = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		myText.text = myPlayer.guncoins.ToString();
	}
}
