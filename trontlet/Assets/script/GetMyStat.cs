using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMyStat : MonoBehaviour {




    //[HideInInspector]
    public float myStat;
    //[HideInInspector]
    public float myMaxStat;


    public bool Health = false;
    public bool Shield = false;

    private PlayerStats myPlayerStats;

    // Use this for initialization
    void Start ()
    {
        myPlayerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Health)
        {
            myStat = myPlayerStats.Health;
            myMaxStat = myPlayerStats.MaxHealth;
        }
    }
}
