using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectColour))]
public class ColourManager : MonoBehaviour {

    public Material mRedMaterial;
    public Material mBlueMaterial;
    public Material mYellowMaterial;

    [HideInInspector]
    public ObjectColour PlayerColour;
	
	void Start () 
    {
        PlayerColour = GetComponent<ObjectColour>();
        PlayerColour.SetMaterials(mRedMaterial, mYellowMaterial, mBlueMaterial);
	}

    
	
}
