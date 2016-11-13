using UnityEngine;
using System.Collections;

public class WardenZone : MonoBehaviour {

    [HideInInspector]
    public bool mPlayerInZone;
    [HideInInspector]
    public bool mWardenInZone;
	
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            mPlayerInZone = true;
        }
        if(col.tag == "Enemy")
        {
            mWardenInZone = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            mPlayerInZone = false;
        }
        if (col.tag == "Enemy")
        {
            mWardenInZone = false;
        }
    }
}
