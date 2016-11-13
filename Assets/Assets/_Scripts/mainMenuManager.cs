using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }	

    public void Exit()
    {
        Application.Quit();
    }
}
