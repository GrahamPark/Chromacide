using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour
{
    [Header("Put the health bar slider here")]
    public Slider mHealthSlider;
    [Header("Put the crosshair image element here")]
    public RawImage mCrosshairImage;
    [Header("Put the health slider fill image element here")]
    public Image mHealthBarFill;
    [Header("Put the health slider background image element here")]
    public Image mHealthBarBG;
    [Header("Put crosshair images here")]
    public Texture mYellowCrosshair;
    public Texture mBlueCrosshair;
    public Texture mRedCrosshair;
    [Header("Put health bar fill mats here")]
    public Material mSpriteYellow;
    public Material mSpriteBlue;
    public Material mSpriteRed;
    [Header("Put health bar background mats here")]
    public Material mSpriteBGYellow;
    public Material mSpriteBGBlue;
    public Material mSpriteBGRed;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        mHealthSlider.value = PlayerManager.sInstance.mHealth;//if not work /100

        if (PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.yellow)
        {
            mCrosshairImage.texture = mYellowCrosshair;
            mHealthBarFill.material = mSpriteYellow;
            mHealthBarBG.material = mSpriteBGYellow;            
        }
        else if (PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.blue)
        {
            mCrosshairImage.texture = mBlueCrosshair;
            mHealthBarFill.material = mSpriteBlue;
            mHealthBarBG.material = mSpriteBGBlue;
        }
        else if (PlayerManager.sInstance.PlayerColour.mObjectColour == ObjectColour.Colour.red)
        {
            mCrosshairImage.texture = mRedCrosshair;
            mHealthBarFill.material = mSpriteRed;
            mHealthBarBG.material = mSpriteBGRed;
        }
    }
}
