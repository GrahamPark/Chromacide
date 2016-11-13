using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    int mCurrentLevel = 1;
    int mTotalLevels;
    public static LevelManager sInstance = null;


    void Start()
    {
        mTotalLevels = SceneManager.sceneCount;
    }

    void Awake()
    {
        if (sInstance == null)
        {
            sInstance = this;
        }

        DontDestroyOnLoad(transform.gameObject);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Reset();
        }
    }
    
    public void Reset()
    {
        PlayerManager.sInstance.mHealth = 18;
        SceneManager.LoadScene(mCurrentLevel);
    }

    public void NextLevel()
    {
        ++mCurrentLevel;
        PlayerManager.sInstance.mHealth = 18;
        SceneManager.LoadScene(mCurrentLevel);

    }
}
