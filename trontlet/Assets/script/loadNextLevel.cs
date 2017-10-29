using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadNextLevel : MonoBehaviour {


	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			Application.LoadLevel(Application.loadedLevel+1);
		}
	}
}

