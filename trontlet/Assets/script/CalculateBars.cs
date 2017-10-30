using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateBars : MonoBehaviour
{
    public GameObject whiteVector;
    public int numberOfBars = 0;
    public int maxNumberOfBars = 10;
    public float barPadding = 0.0f;
    private float barXSpacing;

    private GetMyStat statInfo;
    private LineRenderer barOutline;
    private int lastNumberOfBars;
    private List<GameObject> barList;

	// Use this for initialization
	void Start ()
    {
        statInfo = gameObject.GetComponentInParent<GetMyStat>();

        barOutline = gameObject.GetComponentInParent<LineRenderer>();
        barXSpacing = (barOutline.GetPosition(1).x-2*barPadding) / (maxNumberOfBars-1);

        barList = new List<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {
        lastNumberOfBars = numberOfBars;
        numberOfBars = Mathf.RoundToInt(maxNumberOfBars * (statInfo.myStat / statInfo.myMaxStat));
        //Debug.Log(lastNumberOfBars.ToString() + " " + numberOfBars.ToString());

        if (numberOfBars != lastNumberOfBars)         
        {
            foreach (GameObject bar in barList)
            {
                Destroy(bar);
            }
            for (int i = 0; i < numberOfBars; i++)
            {
                GameObject go = GameObject.Instantiate(whiteVector) as GameObject;
                go.transform.SetParent(transform);
                go.transform.localPosition = Vector3.zero;
                go.transform.localRotation = Quaternion.identity;
                go.transform.localScale = Vector3.one;
                barList.Add(go);


                LineRenderer lr = go.transform.GetComponent<LineRenderer>();
                lr.positionCount = 2;
                lr.loop = false;
                lr.useWorldSpace = false;
                lr.SetPosition(0, new Vector3(i * barXSpacing + barPadding, -barPadding, 0.0f));
                lr.SetPosition(1, barOutline.GetPosition(3) + new Vector3(i * barXSpacing + barPadding, +barPadding, 0.0f));
            }
            
        }

    }
}
