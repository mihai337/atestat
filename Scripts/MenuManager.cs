using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject levelPanel;
    public GameObject settingsPanel;

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ChangeMenu()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
        levelPanel.SetActive(!levelPanel.activeSelf);
    }

    public void ChangeSettings()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
