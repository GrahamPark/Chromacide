using UnityEngine;
using System.Collections;

public class Warden : Enemy{

    //    WARDEN
    //Movement: Slowly moves toward player but doesn’t leave its spawn area.
    //Behavior: Fires at player when in sphere of sight.
    //Health: 5.
    //Attack: Medium speed projectiles.
    //Rate of Fire: 2/second.
    //Damage: 1.

    public WardenZone wardenZone;
    public CheckZone mCheckPlayer;

    public float mMovementSpeed;
    public float mRotationSpeed;

    public Transform[] mLocations;

    int mTotalLocations;
    int mCurrLocation;

    bool mToFinalPosition = true;


    float mNextShot = 0.0f;
    float mTimeDecrease = 0.1f;

    public Transform mGunPosition;
    public float mWeaponRange = 50f;
    public float mFireRate;

    RaycastHit mHit;
    bool mDrawLine;

    private WaitForSeconds mShotDuritation = new WaitForSeconds(.07f);
    private LineRenderer mLaserLine;

    bool mInArea = true;
    bool mPlayerInArea = false;
    bool mPlayerInHitZone = false;

    public GameObject mCorePiece1;

    public GameObject mCorePiece2;

    public GameObject mCorePiece3;

    //area mArea;

    void Start ()
    {
        mLaserLine = GetComponent<LineRenderer>();
        mEnemyColour = GetComponent<ObjectColour>();
        mTotalLocations = mLocations.Length;
        mCurrLocation = 0;
    }
	
	
	void Update ()
    {
        mInArea = wardenZone.mWardenInZone;
        mPlayerInArea = wardenZone.mPlayerInZone;
        mPlayerInHitZone = mCheckPlayer.mInZone;

        if (mEnemyColour.mObjectColour == PlayerManager.sInstance.PlayerColour.mObjectColour)
        {
            mPlayerInArea = false;
        }

        if (!mPlayerInArea)
        {
            if (Mathf.Approximately(transform.position.x,mLocations[mCurrLocation].position.x) && Mathf.Approximately(transform.position.y, mLocations[mCurrLocation].position.y) && Mathf.Approximately(transform.position.z, mLocations[mCurrLocation].position.z))
            {
                if(mCurrLocation == mTotalLocations - 1)
                {
                    mToFinalPosition = false;
                }
                else if(mCurrLocation == 0)
                {
                    mToFinalPosition = true;
                }


                if (mToFinalPosition)
                {
                    ++mCurrLocation;
                }
                else
                {
                    --mCurrLocation;
                }
            }
            else
            {
                transform.LookAt(mLocations[mCurrLocation]);
                transform.position = Vector3.MoveTowards(transform.position, mLocations[mCurrLocation].position, mMovementSpeed * Time.deltaTime);
            }
        }
        else
        {
            this.transform.LookAt(PlayerManager.sInstance.mPlayerPosition.position);
            if (mInArea && mEnemyColour.mObjectColour != PlayerManager.sInstance.PlayerColour.mObjectColour)
            {
                transform.position = Vector3.MoveTowards(transform.position,PlayerManager.sInstance.mPlayerPosition.position, mMovementSpeed * Time.deltaTime);
                if (mPlayerInHitZone && mEnemyColour.mObjectColour != PlayerManager.sInstance.PlayerColour.mObjectColour)
                if (mPlayerInHitZone && Time.time > mNextShot && mEnemyColour.mObjectColour != PlayerManager.sInstance.PlayerColour.mObjectColour)
                {

                    mNextShot = Time.time + mFireRate;

                    Shoot();

                }
            }
            
        }

        if (mEnemyColour.mObjectColour == ObjectColour.Colour.blue)
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

    
}
