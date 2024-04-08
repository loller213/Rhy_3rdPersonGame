using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    private static PointSystem _instance;
    public static PointSystem Instance => _instance;

    private int pointsCovered;
    private int toAdd;
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
        toAdd = 1;
        pointsCovered = 0;
    }


    public void addPoint()
    {
        pointsCovered += toAdd;
    }

    public void subtractPoint()
    {
        pointsCovered -= toAdd;
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

}
