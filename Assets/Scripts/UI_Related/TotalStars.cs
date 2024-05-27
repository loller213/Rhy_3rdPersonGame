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
        if(currScore ==  null || totalScore == null)
        {
            Debug.LogError("Text UI not found");
        }
        StarInitialization();
    }

    private void StarInitialization()
    {
        // get data
        Levels = PrefName.Length;

        // show data
        if (AddAllStars() > 0) 
        {
            currScore.text = TotalStars.ToString("D2");
            var totalStarPerLevel = Levels * numStarPerLevel;
            totalScore.text = totalStarPerLevel.ToString("D2");
        }
    }
}
