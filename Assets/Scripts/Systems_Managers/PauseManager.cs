using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    private static PauseManager _instance;
    public static PauseManager Instance => _instance;

    public GameObject pauseScreen;
    [SerializeField] private bool isPaused;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (!isPaused && !PointSystem.Instance.levelState())
            {
                GamePaused();
            }else if (isPaused && !PointSystem.Instance.levelState())
            {
                GameUnpaused();
            }

        }
    }

    public void GamePaused()
    {
        Time.timeScale = 0; 
        isPaused = true;
        pauseScreen.SetActive(true);
    }

    public void GameUnpaused()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseScreen.SetActive(false);
    }

    public bool PausedState()
    {
        return isPaused;
    }

    public void StageCounter()
    {

    }


}
