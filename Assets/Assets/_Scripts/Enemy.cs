using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectColour))]
public class Enemy : MonoBehaviour{
    [HideInInspector]
    public ObjectColour mEnemyColour;
    public int mHealth;
    public int mDamage;
    public GameObject mWholePrefab;

    void Start()
    {
        mEnemyColour = GetComponent<ObjectColour>();
    }

    void AddHealth(int health)
    {
        mHealth += health;
        if (mHealth <= 0)
        {
            Destroy(mWholePrefab);
        }
    }



    /*
     red > yellow > blue > red
     
     */

    public void Hit(int damage)
    {
        if (PlayerManager.sInstance.PlayerColour.mObjectColour != mEnemyColour.mObjectColour)
        {
            if (PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.red && mEnemyColour.mObjectColour == ObjectColour.Colour.yellow)
            {
                mHealth -= (damage * 3);
            }
            else if (PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.red && mEnemyColour.mObjectColour == ObjectColour.Colour.blue)
            {
                //mHealth -= damage;
            }
            if (PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.blue && mEnemyColour.mObjectColour == ObjectColour.Colour.yellow)
            {
                //mHealth -= damage;
            }
            else if (PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.blue && mEnemyColour.mObjectColour == ObjectColour.Colour.red)
            {
                mHealth -= (damage * 3);
            }
            if (PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.yellow && mEnemyColour.mObjectColour == ObjectColour.Colour.red)
            {
                //mHealth -= damage;
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
