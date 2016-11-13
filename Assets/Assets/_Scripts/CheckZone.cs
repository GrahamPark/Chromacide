using UnityEngine;
using System.Collections;

public class CheckZone : MonoBehaviour {

    public bool mInZone = false;


    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            mInZone = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            mInZone = false;
        }
    }
}
