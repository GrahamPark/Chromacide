using UnityEngine;
using System.Collections;

public class FinishLevel : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            LevelManager.sInstance.NextLevel();
        }
    }
}
