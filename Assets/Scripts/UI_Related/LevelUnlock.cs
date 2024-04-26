using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour
{
    [SerializeField] private Button[] levels;

    private void Start()
    {
        UnlockAvailableLevels();
    }

    private void UnlockAvailableLevels()
    {
        levels[0].interactable = true;

        //Level 2 unlock
        if (PlayerPrefs.GetInt("Level1_Stars") >= 2)
        {
            levels[1].interactable = true;
        }
        else
        {
            levels[1].interactable = false;
        }

        //Level 3 unlock
        if (PlayerPrefs.GetInt("Level2_Stars") >= 2)
        {
            levels[2].interactable = true;
        }
        else
        {
            levels[2].interactable = false;
        }

        //Level 4 unlock
        if (PlayerPrefs.GetInt("Level3_Stars") >= 2)
        {
            levels[3].interactable = true;
        }
        else
        {
            levels[3].interactable = false;
        }

        //Level 5 unlock
        if (PlayerPrefs.GetInt("Level4_Stars") >= 2)
        {
            levels[4].interactable = true;
        }
        else
        {
            levels[4].interactable = false;
        }

        //Level 6 unlock
        if (PlayerPrefs.GetInt("Level5_Stars") >= 2)
        {
            levels[5].interactable = true;
        }
        else
        {
            levels[5].interactable = false;
        }

        //Level 7 unlock
        if (PlayerPrefs.GetInt("Level6_Stars") >= 2)
        {
            levels[6].interactable = true;
        }
        else
        {
            levels[6].interactable = false;
        }

        //Level 8 unlock
        if (PlayerPrefs.GetInt("Level7_Stars") >= 2)
        {
            levels[7].interactable = true;
        }
        else
        {
            levels[7].interactable = false;
        }

        //Level 9 unlock
        if (PlayerPrefs.GetInt("Level8_Stars") >= 2)
        {
            levels[8].interactable = true;
        }
        else
        {
            levels[8].interactable = false;
        }

        //Level 10 unlock
        if (PlayerPrefs.GetInt("Level9_Stars") >= 2)
        {
            levels[9].interactable = true;
        }
        else
        {
            levels[9].interactable = false;
        }

        //Level 11 unlock
        if (PlayerPrefs.GetInt("Level10_Stars") >= 2)
        {
            levels[10].interactable = true;
        }
        else
        {
            levels[10].interactable = false;
        }

        //Level 12 unlock9
        if (PlayerPrefs.GetInt("Level11_Stars") >= 2)
        {
            levels[11].interactable = true;
        }
        else
        {
            levels[11].interactable = false;
        }

        //Level 13 unlock
        if (PlayerPrefs.GetInt("Level12_Stars") >= 2)
        {
            levels[12].interactable = true;
        }
        else
        {
            levels[12].interactable = false;
        }

        //Level 14 unlock
        if (PlayerPrefs.GetInt("Level13_Stars") >= 2)
        {
            levels[13].interactable = true;
        }
        else
        {
            levels[13].interactable = false;
        }

        //Level 15 unlock
        if (PlayerPrefs.GetInt("Level14_Stars") >= 2)
        {
            levels[14].interactable = true;
        }
        else
        {
            levels[14].interactable = false;
        }

    }
}
