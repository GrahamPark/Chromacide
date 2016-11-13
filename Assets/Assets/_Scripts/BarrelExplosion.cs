using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectColour))]
public class BarrelExplosion : MonoBehaviour
{
    public GameObject mExplosion;
    public GameObject mWall;
    ObjectColour mBarrelColour;
    Renderer mCachedRend;
    Renderer mExplosionRend;
    
    public bool mWasShot = false;

    void Start()
    {
        mBarrelColour = GetComponent<ObjectColour>();
        mCachedRend = GetComponent<Renderer>();

    }

    void Update()
    {

        if (mBarrelColour.mObjectColour == ObjectColour.Colour.yellow)
        {
            mCachedRend.material = PlayerManager.sInstance.PlayerColour.GetYellowMat();
        }
        else if (mBarrelColour.mObjectColour == ObjectColour.Colour.blue)
        {
            mCachedRend.material = PlayerManager.sInstance.PlayerColour.GetBlueMat();
        }
        else if (mBarrelColour.mObjectColour == ObjectColour.Colour.red)
        {
            mCachedRend.material = PlayerManager.sInstance.PlayerColour.GetRedMat();
        }

        if (mWasShot)
        {
            
            GameObject go = (GameObject)Instantiate(mExplosion, gameObject.transform.position, Quaternion.identity);
            mExplosionRend = go.GetComponent<Renderer>();

            if (mBarrelColour.mObjectColour == ObjectColour.Colour.yellow)
            {
                mExplosionRend.material = PlayerManager.sInstance.PlayerColour.GetYellowMat();
            }
            else if (mBarrelColour.mObjectColour == ObjectColour.Colour.blue)
            {
                mExplosionRend.material = PlayerManager.sInstance.PlayerColour.GetBlueMat();
            }
            else if (mBarrelColour.mObjectColour == ObjectColour.Colour.red)
            {
                mExplosionRend.material = PlayerManager.sInstance.PlayerColour.GetRedMat();
            }

            Destroy(mWall);
            Destroy(gameObject);
        }
    }

    /*
     red > yellow > blue > red
     
     */

    public void Shot()
    {
        if (mBarrelColour.mObjectColour != PlayerManager.sInstance.PlayerColour.mObjectColour)
        {
            if (mBarrelColour.mObjectColour == ObjectColour.Colour.red && PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.blue)
            {
                mWasShot = true;
            }
            if (mBarrelColour.mObjectColour == ObjectColour.Colour.blue && PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.yellow)
            {
                mWasShot = true;
            }
            if (mBarrelColour.mObjectColour == ObjectColour.Colour.yellow && PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.red)
            {
                mWasShot = true;
            }
        }
    }
}
