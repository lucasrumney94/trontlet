using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySelfBlockingEntrance : MonoBehaviour
{

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Entrance"))
        {
            Destroy(gameObject);
        }
    }

}
