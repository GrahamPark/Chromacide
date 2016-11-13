using UnityEngine;
using System.Collections;

public class GunColour : MonoBehaviour {

    Renderer mCachedRend;

	void Start ()
    {
        mCachedRend = GetComponent<Renderer>();
    }
	
	
	void Update ()
    {
        if (PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.yellow)
        {
            mCachedRend.material = PlayerManager.sInstance.PlayerColour.GetYellowMat();
        }
        else if (PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.blue)
        {
            mCachedRend.material = PlayerManager.sInstance.PlayerColour.GetBlueMat();
        }
        else if (PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.red)
        {
            mCachedRend.material = PlayerManager.sInstance.PlayerColour.GetRedMat();
        }
    }
}
