using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class TotalStars : ModeUnlock
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text totalScore;
    [SerializeField] private int Levels = 15;
    [SerializeField] private int numStarPerLevel = 3;

    protected override void Start()
    {
        StarInitialization();
    }

    private void StarInitialization()
    {
        AddAllStars();
        if (scoreText != null && totalScore !=null) 
        {
            scoreText.text = TotalStars.ToString("D2");
            var totalStarPerLevel = Levels * numStarPerLevel;
            totalScore.text = totalStarPerLevel.ToString("D2");
        }
    }
}
