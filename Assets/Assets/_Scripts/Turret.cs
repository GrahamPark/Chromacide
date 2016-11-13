using UnityEngine;
using System.Collections;

public class Turret : Enemy{

    //in the enemy class
    //public ObjectColour mEnemyColour;
    //public int mHealth;
    //public int mDamage;

    bool mInZone = false;
    float mNextShot = 0.0f;
    float mTimeDecrease = 0.1f;


    public LookAt mTurretHead;

    public Transform mGunPosition;
    public float mWeaponRange = 50f;
    public float mFireRate;

    RaycastHit mHit;
    bool mDrawLine;


    private WaitForSeconds mShotDuritation = new WaitForSeconds(.07f);
    private LineRenderer mLaserLine;

    public GameObject mCorePiece1;

    public GameObject mCorePiece2;

    public GameObject mCorePiece3;


    void Start ()
    {
        mLaserLine = GetComponent<LineRenderer>();
        mEnemyColour = GetComponent<ObjectColour>();
	}


    void Shoot()
    {
        
        StartCoroutine(ShotEffect());

        Vector3 rayOrigin = mGunPosition.position;
        RaycastHit hit;

        mLaserLine.SetPosition(0, mGunPosition.position);

        if (Physics.Raycast(rayOrigin, this.transform.forward, out hit, mWeaponRange))
        {
            mLaserLine.SetPosition(1, hit.point);
        }
        else
        {
            mLaserLine.SetPosition(1, rayOrigin + (this.transform.forward * mWeaponRange));
        }

        if (hit.collider.tag == "Player")
        {
            PlayerManager.sInstance.EnemyHit(mEnemyColour.mObjectColour, mDamage);
        }
    }

    private IEnumerator ShotEffect()
    {
        mLaserLine.enabled = true;

        if (mEnemyColour.mObjectColour == ObjectColour.Colour.yellow)
        {
            mLaserLine.material = PlayerManager.sInstance.PlayerColour.GetYellowMat();
        }
        else if (mEnemyColour.mObjectColour == ObjectColour.Colour.blue)
        {
            mLaserLine.material = PlayerManager.sInstance.PlayerColour.GetBlueMat();
        }
        else if (mEnemyColour.mObjectColour == ObjectColour.Colour.red)
        {
            mLaserLine.material = PlayerManager.sInstance.PlayerColour.GetRedMat();
        }

        yield return mShotDuritation;
        mLaserLine.enabled = false;
    }

	void Update () 
    {
        


        if (mInZone && mEnemyColour.mObjectColour != PlayerManager.sInstance.PlayerColour.mObjectColour)
        {
            this.transform.LookAt(PlayerManager.sInstance.mPlayerPosition.position);
        }
        
        if (mInZone && Time.time > mNextShot && mEnemyColour.mObjectColour != PlayerManager.sInstance.PlayerColour.mObjectColour)
        {
            mNextShot = Time.time + mFireRate;
            
            Shoot();

        }
        if(mEnemyColour.mObjectColour == ObjectColour.Colour.blue)
        {
            mCorePiece1.GetComponent<Renderer>().material = PlayerManager.sInstance.PlayerColour.GetBlueMat();
            mCorePiece2.GetComponent<Renderer>().material = PlayerManager.sInstance.PlayerColour.GetBlueMat();
            mCorePiece3.GetComponent<Renderer>().material = PlayerManager.sInstance.PlayerColour.GetBlueMat();
        }
        else if (mEnemyColour.mObjectColour == ObjectColour.Colour.yellow)
        {
            mCorePiece1.GetComponent<Renderer>().material = PlayerManager.sInstance.PlayerColour.GetYellowMat();
            mCorePiece2.GetComponent<Renderer>().material = PlayerManager.sInstance.PlayerColour.GetYellowMat();
            mCorePiece3.GetComponent<Renderer>().material = PlayerManager.sInstance.PlayerColour.GetYellowMat();
        }
        else if (mEnemyColour.mObjectColour == ObjectColour.Colour.red)
        {
            mCorePiece1.GetComponent<Renderer>().material = PlayerManager.sInstance.PlayerColour.GetRedMat();
            mCorePiece2.GetComponent<Renderer>().material = PlayerManager.sInstance.PlayerColour.GetRedMat();
            mCorePiece3.GetComponent<Renderer>().material = PlayerManager.sInstance.PlayerColour.GetRedMat();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            mInZone = true;
            mNextShot = Time.time + mFireRate;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            mInZone = false;
            mNextShot = 0.0f;
        }
    }
}
