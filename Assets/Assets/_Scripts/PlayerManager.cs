using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectColour))]
public class PlayerManager : MonoBehaviour {

    public static PlayerManager sInstance = null;

    public Transform mPlayerPosition;

    public int mHealth;

    [HideInInspector]
    public ObjectColour PlayerColour;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

	void Start () 
    {
        if (sInstance == null)
        {
            sInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        PlayerColour = GetComponent<ObjectColour>();

	}
	/*
     red > yellow > blue > red
     
     */

    public void EnemyHit(ObjectColour.Colour enemyColour,int damage)
    {
        if (enemyColour != PlayerColour.mObjectColour)
        {
            if (enemyColour == ObjectColour.Colour.red && PlayerColour.mObjectColour == ObjectColour.Colour.yellow)
            {
                mHealth -= (damage * 3);
            }
            else if (enemyColour == ObjectColour.Colour.red && PlayerColour.mObjectColour == ObjectColour.Colour.blue)
            {
                mHealth -= damage;
            }
            if (enemyColour == ObjectColour.Colour.blue && PlayerColour.mObjectColour == ObjectColour.Colour.yellow)
            {
                mHealth -= damage;
            }
            else if (enemyColour == ObjectColour.Colour.blue && PlayerColour.mObjectColour == ObjectColour.Colour.red)
            {
                mHealth -= (damage * 3);
            }
            if (enemyColour == ObjectColour.Colour.yellow && PlayerColour.mObjectColour == ObjectColour.Colour.red)
            {
                mHealth -= damage;
            }
            else if (enemyColour == ObjectColour.Colour.yellow && PlayerColour.mObjectColour == ObjectColour.Colour.blue)
            {
                mHealth -= (damage * 3);
            }
        }

        if(mHealth <= 0)
        {
            LevelManager.sInstance.Reset();
        }
    }
	
	void Update () 
    {
        print(mHealth);
	}
}
