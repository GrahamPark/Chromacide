using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectColour))]
public class Explosion : MonoBehaviour
{
    public float mDuration;
    public float mScaleIncreaseFactor;

    void Update()
    {
        if(mDuration < 0)
        {
            Destroy(gameObject);
        }

        mDuration = mDuration - Time.deltaTime;
        gameObject.transform.localScale = gameObject.transform.localScale * mScaleIncreaseFactor;
    }
}
