using UnityEngine;
using System.Collections;


public class Hoplite : Enemy {

    public int mShieldHealth;
    bool mShieldUp = true;
    public GameObject mFullShield;


    public ObjectColour mShieldColour;

    public Renderer mShieldRend;

    public Renderer mCorePiece1;
    public Renderer mCorePiece2;
    public Renderer mCorePiece3;

    public Material mSeeThroughBlue;
    public Material mSeeThroughRed;
    public Material mSeeThroughYellow;


    bool mPlayerInZone = false;

    void Start ()
    {
        mEnemyColour = GetComponent<ObjectColour>();
    }
	
	
	void Update ()
    {
        

        if (mShieldUp)
        {
            if (mShieldColour.mObjectColour == ObjectColour.Colour.yellow)
            {
                mShieldRend.material = mSeeThroughYellow;
                mEnemyColour.mObjectColour = ObjectColour.Colour.red;
                mCorePiece1.material = PlayerManager.sInstance.PlayerColour.GetRedMat();
                mCorePiece2.material = PlayerManager.sInstance.PlayerColour.GetRedMat();
                mCorePiece3.material = PlayerManager.sInstance.PlayerColour.GetRedMat();
            }
            else if (mShieldColour.mObjectColour == ObjectColour.Colour.blue)
            {
                mShieldRend.material = mSeeThroughBlue;
                mEnemyColour.mObjectColour = ObjectColour.Colour.yellow;
                mCorePiece1.material = PlayerManager.sInstance.PlayerColour.GetYellowMat();
                mCorePiece2.material = PlayerManager.sInstance.PlayerColour.GetYellowMat();
                mCorePiece3.material = PlayerManager.sInstance.PlayerColour.GetYellowMat();
            }
            else if (mShieldColour.mObjectColour == ObjectColour.Colour.red)
            {
                mShieldRend.material = mSeeThroughRed;
                mEnemyColour.mObjectColour = ObjectColour.Colour.blue;
                mCorePiece1.material = PlayerManager.sInstance.PlayerColour.GetBlueMat();
                mCorePiece2.material = PlayerManager.sInstance.PlayerColour.GetBlueMat();
                mCorePiece3.material = PlayerManager.sInstance.PlayerColour.GetBlueMat();
            }
        }

        if (mPlayerInZone)
        {
            transform.LookAt(PlayerManager.sInstance.mPlayerPosition.position);
        }
        


    }

    new public void Hit(int damage)
    {
        if (mShieldUp)
        {
            if (mShieldColour.mObjectColour != mEnemyColour.mObjectColour)
            {
                if (mShieldColour.mObjectColour == ObjectColour.Colour.red && mEnemyColour.mObjectColour == ObjectColour.Colour.yellow)
                {
                    mShieldHealth -= (damage * 3);
                }
                else if (mShieldColour.mObjectColour == ObjectColour.Colour.red && mEnemyColour.mObjectColour == ObjectColour.Colour.blue)
                {
                    mShieldHealth -= damage;
                }
                if (mShieldColour.mObjectColour == ObjectColour.Colour.blue && mEnemyColour.mObjectColour == ObjectColour.Colour.yellow)
                {
                    mShieldHealth -= damage;
                }
                else if (mShieldColour.mObjectColour == ObjectColour.Colour.blue && mEnemyColour.mObjectColour == ObjectColour.Colour.red)
                {
                    mShieldHealth -= (damage * 3);
                }
                if (mShieldColour.mObjectColour == ObjectColour.Colour.yellow && mEnemyColour.mObjectColour == ObjectColour.Colour.red)
                {
                    mShieldHealth -= damage;
                }
                else if (mShieldColour.mObjectColour == ObjectColour.Colour.yellow && mEnemyColour.mObjectColour == ObjectColour.Colour.blue)
                {
                    mShieldHealth -= (damage * 3);
                }
            }
            if(mShieldHealth <= 0)
            {
                mShieldUp = false;
                Destroy(mFullShield);
            }
        }
        else
        {
            if (PlayerManager.sInstance.PlayerColour.mObjectColour != mEnemyColour.mObjectColour)
            {
                if (PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.red && mEnemyColour.mObjectColour == ObjectColour.Colour.yellow)
                {
                    mHealth -= (damage * 3);
                }
                else if (PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.red && mEnemyColour.mObjectColour == ObjectColour.Colour.blue)
                {
                    mHealth -= damage;
                }
                if (PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.blue && mEnemyColour.mObjectColour == ObjectColour.Colour.yellow)
                {
                    mHealth -= damage;
                }
                else if (PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.blue && mEnemyColour.mObjectColour == ObjectColour.Colour.red)
                {
                    mHealth -= (damage * 3);
                }
                if (PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.yellow && mEnemyColour.mObjectColour == ObjectColour.Colour.red)
                {
                    mHealth -= damage;
                }
                else if (PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.yellow && mEnemyColour.mObjectColour == ObjectColour.Colour.blue)
                {
                    mHealth -= (damage * 3);
                }
            }
            if (mHealth <= 0)
            {
                Destroy(mWholePrefab);
            }
        }
       
    }
}
