using UnityEngine;
using System.Collections;

public class KeepOnLoad : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
