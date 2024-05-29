using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    private static PauseManager _instance;
    public static PauseManager Instance => _instance;

    public GameObject pauseScreen;
    public bool isPaused;

    private void Awake()
    {   
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        GameUnpaused();
    }

    private void Update()
    {
        if (SceneManagerScript.Instance.GetCurrentSceneName() != "LevelSelector")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isPaused && !PointSystem.Instance.levelState())
                {
                    GamePaused();

                    // if (!MapManager.Instance.mapScreen.activeSelf) return;
                    //
                    // MapManager.Instance.mapScreen.SetActive(false);
                    // MapManager.Instance.isShown = false;
                }
                else if (isPaused && !PointSystem.Instance.levelState())
                {
                    GameUnpaused();
                }
            }
        }
        else
        {
            return;
        }
    }

    public void GamePaused()
    {
        Time.timeScale = 0; 
        isPaused = true;
        MouseLockManager.Instance.UnlockMouse();
        pauseScreen.SetActive(true);
    }

    public void GameUnpaused()
    {
        Time.timeScale = 1;
        isPaused = false;
        MouseLockManager.Instance.LockMouse();
        pauseScreen.SetActive(false);
    }

    public bool PausedState()
    {
        return isPaused;
    }

}
