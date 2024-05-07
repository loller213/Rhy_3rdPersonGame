using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinSystem_UIController : MonoBehaviour
{
    private static WinSystem_UIController _instance;
    public static WinSystem_UIController Instance => _instance;

    public TextMeshProUGUI endTimerUI;
    public GameObject star1, star2, star3;
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
        timer = 0;
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
    }

    public void ActivateWinconditionScreen()
    {
        FinalizedTimer();
        StarsDisplay();
    }

    private void StarsDisplay()
    {
        if (timer >= 900)
        {
            //MinimumStars
            Debug.Log("Win get 1 Star");
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);

        }
        else if (timer >= 300 && timer <= 600)
        {
            //2 Stars
            Debug.Log("Win get 2 Stars");
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);

        }
        else if (timer <= 300)
        {
            //Maximum Stars
            Debug.Log("Win get 3 Stars");
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);

        }
    }

    private void FinalizedTimer()
    {
        timer = TimerScript.Instance.ReturnTimer();

        int hours = (int)(timer / 3600);
        int minutes = (int)((timer / 60) % 60);
        int seconds = (int)(timer % 60);
        int milliseconds = (int)((timer * 100) % 100);

        endTimerUI.text = "Time: " + string.Format("{0:00}:{1:00}:{2:00}:{3:00}", hours, minutes, seconds, milliseconds);
    }

}
