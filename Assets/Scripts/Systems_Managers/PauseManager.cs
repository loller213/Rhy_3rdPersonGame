using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    public GameObject pauseScreen;
    [SerializeField] private bool isPaused;

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

    public void StageCounter()
    {

    }


}
