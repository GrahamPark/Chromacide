using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

    public bool mLookAtPlayer;
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (mLookAtPlayer)
        {
            this.transform.LookAt(PlayerManager.sInstance.mPlayerPosition.position);
        }
        
	}
}
