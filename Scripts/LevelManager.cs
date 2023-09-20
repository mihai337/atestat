using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform RespawnPoint;
    public GameObject playerPrefab;
    public CinemachineVirtualCameraBase cam;
    public Text attemptsCount;
    public int attempts=0;


    private void Start()
    {
       

    }


    private void Awake()
    {
        if (LevelManager.instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void Respawn()
    {
        
        Instantiate(playerPrefab, RespawnPoint.position, Quaternion.identity);
        
        
    }

    public void GameOver()
    {
        UIManager ui = GetComponent<UIManager>();
        if(ui != null)
        {
            ui.ToggleDeathPanel();
        }
    }
}
