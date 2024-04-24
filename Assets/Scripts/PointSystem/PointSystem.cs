using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    private static PointSystem _instance;
    public static PointSystem Instance => _instance;

    [SerializeField] private int pointsCovered;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject restartButton;

    private int modifyer;
    private bool win;

    public bool levelWin;
    public int getPtsCvrd;
    

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

        EventManager.ON_AREA_ENTER += addPoint;
        EventManager.ON_AREA_LEAVE += subtractPoint;
    }

    private void Start()
    {
        win = false;
        levelWin = false;
        winScreen.SetActive(false);
        restartButton.SetActive(false);
        modifyer = 1;
        pointsCovered = 0;
    }

    public void addPoint()
    {
        pointsCovered += modifyer;
        CheckLevelRequirement();
    }

    public void subtractPoint()
    {
        pointsCovered -= modifyer;
        CheckLevelRequirement();
    }

    private void OnDestroy()
    {
        EventManager.ON_AREA_ENTER -= addPoint;
        EventManager.ON_AREA_LEAVE -= subtractPoint;
    }

    public int GetPointsCovered()
    {
        getPtsCvrd = pointsCovered;
        return getPtsCvrd;
    }

    private void CheckLevelRequirement()
    {
        if (CurrentStageRequirement.Instance.getLevelRequirement() == pointsCovered)
        {
            win = true;
            if (win)
            {                
                levelWin = win;
                CameraManager.Instance.UnlockMouse();

                Time.timeScale = 1; 
                
                winScreen.SetActive(true);
                restartButton.SetActive(true);
            }
        }
        else if (CurrentStageRequirement.Instance.getLevelRequirement() != pointsCovered)
        {
            Debug.Log("Missing Area!");
        }
    }

    public bool levelState()
    {
        levelWin = win;
        return levelWin;
    }

}
