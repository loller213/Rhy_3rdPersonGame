using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TimerScript : MonoBehaviour
{
    private static TimerScript _instance;
    public static TimerScript Instance => _instance;

    [SerializeField] private TextMeshProUGUI timerTxt;
    [SerializeField] private float timer;

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
        Time.timeScale = 1;
        timer = 0;
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
        timer += Time.deltaTime;

        int hours = (int)(timer / 3600);
        int minutes = (int)((timer / 60) % 60);
        int seconds = (int)(timer % 60);
        int milliseconds = (int)((timer * 100) % 100);

        timerTxt.text = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", hours, minutes, seconds, milliseconds);
    }

    public void CheckTimer()
    {
        Debug.Log("Current Seconds: " + timer);

        if (timer >= 900)
        {
            //MinimumStars
            Debug.Log("Level get 1 star");
            StarsSystem.Instance.StarAssignment(1);
            PlayerPrefs.Save();
        }else if (timer >= 300 && timer <= 600)
        {
            //2 Stars
            Debug.Log("Level get 2 stars");
            StarsSystem.Instance.StarAssignment(2);
            PlayerPrefs.Save();
        }
        else if (timer <= 300)
        {
            //Maximum Stars
            Debug.Log("Level get 3 stars");
            StarsSystem.Instance.StarAssignment(3);
            PlayerPrefs.Save();
        }
    }

    public float ReturnTimer()
    {
        return timer;
    }
}
