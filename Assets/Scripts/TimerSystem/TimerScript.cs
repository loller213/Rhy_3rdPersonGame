using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerTxt;
    [SerializeField] private float remainingTime;

    private void Start()
    {
        remainingTime = 0;
    }
    // Update is called once per frame
    void Update()
    {

        if (!PointSystem.Instance.levelState())
        {
            Timer();
        }
    }

    private void Timer()
    {
        remainingTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerTxt.text = string.Format("TIME: {0:00}:{1:00}", minutes, seconds);
    }

    private void CheckTimer()
    {

    }
}
