using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectColour))]
public class PlayerGun : MonoBehaviour {

    public Transform mGunPosition;
    public float mWeaponRange = 50f;
    public float fireRate;
    public int mDamage;

    RaycastHit mHit;
    bool mDrawLine;

    private Camera mCam;
    private WaitForSeconds mShotDuritation = new WaitForSeconds(.07f);
    private WaitForSeconds mAnimationTimer = new WaitForSeconds(.1f);
    private LineRenderer mLaserLine;
    private float nextFire;

	void Start () 
    {
        mLaserLine = GetComponent<LineRenderer>();
        mCam = GetComponentInParent<Camera>();
	}
	
	
	void Update () 
    {
        if (Input.GetButtonDown("Fire1"))// && Time.time > nextFire
        {
            

            nextFire = Time.time + nextFire;
            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = mCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            mLaserLine.SetPosition(0, mGunPosition.position);

            if (Physics.Raycast(rayOrigin, mCam.transform.forward, out hit, mWeaponRange))
            {
                mLaserLine.SetPosition(1, hit.point);
                if (hit.collider.tag == "Enemy")
                {
                    Enemy enemy = hit.collider.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        enemy.Hit(mDamage);
                    }
                }
                if(hit.collider.tag == "Barrel")
                {
                    BarrelExplosion barrel = hit.collider.GetComponent<BarrelExplosion>();
                    if (barrel != null)
                    {
                        barrel.Shot();
                    }
                }
                if (hit.collider.tag == "Hoplite")
                {
                    Hoplite enemy = hit.collider.GetComponent<Hoplite>();
                    if (enemy != null)
                    {
                        enemy.Hit(mDamage);
                    }
                }
            }
            else
            {
                mLaserLine.SetPosition(1, rayOrigin + (mCam.transform.forward * mWeaponRange));
                
            }
            
            
            
        }
	}


    private IEnumerator ShotEffect()
    {
        mLaserLine.enabled = true;

        if (PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.yellow)
        {
            mLaserLine.material = PlayerManager.sInstance.PlayerColour.GetYellowMat();
        }
        else if (PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.blue)
        {
            mLaserLine.material = PlayerManager.sInstance.PlayerColour.GetBlueMat();
        }
        else if (PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.red)
        {
            mLaserLine.material = PlayerManager.sInstance.PlayerColour.GetRedMat();
        }

        yield return mShotDuritation;
        mLaserLine.enabled = false;
    }

}
