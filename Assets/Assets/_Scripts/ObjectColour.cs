using UnityEngine;
using System.Collections;

public class ObjectColour : MonoBehaviour {

    public enum Colour
    {
        red = 0,
        blue,
        yellow
    }

    static public Material mRedColour = null;
    static public Material mYellowColour = null;
    static public Material mBlueColour = null;

    public void SetMaterials(Material red,Material yellow,Material blue)
    {
        mRedColour = red;
        mYellowColour = yellow;
        mBlueColour = blue;
    }

    public Material GetRedMat()
    {
        return mRedColour;
    }

    public Material GetYellowMat()
    {
        return mYellowColour;
    }

    public Material GetBlueMat()
    {
        return mBlueColour;
    }

    public Colour mObjectColour;

}
