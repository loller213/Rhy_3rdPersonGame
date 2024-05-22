using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalStars : ModeUnlock
{
    [SerializeField] private TMP_Text currScore;
    [SerializeField] private TMP_Text totalScore;
    [SerializeField] private int numStarPerLevel = 3;
    private int Levels = 15;

    protected override void Start()
    {
        StarInitialization();
    }

    private void StarInitialization()
    {
        // get data
        AddAllStars();
        Levels = PrefName.Length;

        // show data
        if (currScore != null && totalScore !=null) 
        {
            currScore.text = TotalStars.ToString("D2");
            var totalStarPerLevel = Levels * numStarPerLevel;
            totalScore.text = totalStarPerLevel.ToString("D2");
        }
    }
}
