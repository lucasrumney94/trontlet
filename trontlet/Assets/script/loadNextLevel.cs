using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadNextLevel : MonoBehaviour {


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Application.LoadLevel(Application.loadedLevel+1);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		}
	}
}

