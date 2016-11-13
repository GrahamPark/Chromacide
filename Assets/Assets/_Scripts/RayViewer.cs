using UnityEngine;
using System.Collections;

public class RayViewer : MonoBehaviour {

    public float mWeaponRange = 50f;

    private Camera mCam;
	
	void Start () 
    {
        mCam = GetComponentInParent<Camera>();
	}
	
	
	void Update () 
    {
        Vector3 lineOrigin = mCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(lineOrigin, mCam.transform.forward * mWeaponRange, Color.green);
	}
}
