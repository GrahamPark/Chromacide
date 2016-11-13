using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectColour))]
public class Gate : MonoBehaviour {

    ObjectColour mGateColour;
    Renderer mCachedRend;

    public bool mIsPickup;

    public Material mYellowMat;
    public Material mBlueMat;
    public Material mRedMat;

    ObjectColour mColliderColour;

    void Start ()
    {
        mGateColour = GetComponent<ObjectColour>();
        mCachedRend = GetComponent<Renderer>();

        if (mGateColour.mObjectColour == ObjectColour.Colour.yellow)
        {
            mCachedRend.material = mYellowMat;
        }
        else if (mGateColour.mObjectColour == ObjectColour.Colour.blue)
        {
            mCachedRend.material = mBlueMat;
        }
        else if (mGateColour.mObjectColour == ObjectColour.Colour.red)
        {
            mCachedRend.material = mRedMat;
        }

    }
	
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            if (mGateColour.mObjectColour == ObjectColour.Colour.yellow)
            {
                PlayerManager.sInstance.PlayerColour.mObjectColour = ObjectColour.Colour.yellow;
            }
            else if (mGateColour.mObjectColour == ObjectColour.Colour.blue)
            {
                PlayerManager.sInstance.PlayerColour.mObjectColour = ObjectColour.Colour.blue;
            }
            else if (mGateColour.mObjectColour == ObjectColour.Colour.red)
            {
                PlayerManager.sInstance.PlayerColour.mObjectColour = ObjectColour.Colour.red;
            }
            if (mIsPickup)
            {
                Destroy(this.gameObject);
            }
        }
        else if (col.tag == "Enemy" && !mIsPickup)
        {
            mColliderColour = col.GetComponent<ObjectColour>();
            if (mGateColour.mObjectColour == ObjectColour.Colour.yellow)
            {
                mColliderColour.mObjectColour = ObjectColour.Colour.yellow;
            }
            else if (mGateColour.mObjectColour == ObjectColour.Colour.blue)
            {
                mColliderColour.mObjectColour = ObjectColour.Colour.blue;
            }
            else if (mGateColour.mObjectColour == ObjectColour.Colour.red)
            {
                mColliderColour.mObjectColour = ObjectColour.Colour.red;
            }
            
        }
        else if (col.tag == "Hoplite" && !mIsPickup)
        {
            Hoplite hoplite = col.GetComponent<Hoplite>();
            mColliderColour = hoplite.mShieldColour;
            if (mGateColour.mObjectColour == ObjectColour.Colour.yellow)
            {
                mColliderColour.mObjectColour = ObjectColour.Colour.yellow;
            }
            else if (mGateColour.mObjectColour == ObjectColour.Colour.blue)
            {
                mColliderColour.mObjectColour = ObjectColour.Colour.blue;
            }
            else if (mGateColour.mObjectColour == ObjectColour.Colour.red)
            {
                mColliderColour.mObjectColour = ObjectColour.Colour.red;
            }

        }
    }
}
