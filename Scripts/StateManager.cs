using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       // LevelManager.instance.attempts++;
        //PlayerPrefs.SetInt("maxAttempts", LevelManager.instance.attempts);
       // LevelManager.instance.attemptsCount.text = "Attempt " + LevelManager.instance.attempts.ToString();
    }

    public void ChangeScene(string name)
    {
        if(name != null)
            SceneManager.LoadScene(name);
    }
}
