using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeUnlock : MonoBehaviour
{
    [SerializeField] private Button modeButton;
    [SerializeField] private int[] starsGot;
    [SerializeField] private string[] prefName;
    [SerializeField] private int totalStars;
    private int starRequirement;

    private void Awake()
    {
        starRequirement = 30;
    }

    private void Start()
    {
        CheckModeUnlock();
    }

    private void CheckModeUnlock()
    {

        if (AddAllStars() >= starRequirement)
        {
            modeButton.interactable = true;
        }
        else
        {
            modeButton.interactable = false;
        }
    }

    private int AddAllStars()
    {
        for (int i = 0; i <= prefName.Length-1; i++)
        {
            starsGot[i] = GetStars(prefName[i]);
            totalStars += starsGot[i];
            Debug.Log(starsGot[i]);
        }

        return totalStars;
    }

    private int GetStars(string name)
    {
        return PlayerPrefs.GetInt(name);
    }


    //PlayerPrefs.GetInt("Level1_Stars");
    //PlayerPrefs.GetInt("Level2_Stars");
    //PlayerPrefs.GetInt("Level3_Stars");
    //PlayerPrefs.GetInt("Level4_Stars");
    //PlayerPrefs.GetInt("Level5_Stars");
    //PlayerPrefs.GetInt("Level6_Stars");
    //PlayerPrefs.GetInt("Level7_Stars");
    //PlayerPrefs.GetInt("Level8_Stars");
    //PlayerPrefs.GetInt("Level9_Stars");
    //PlayerPrefs.GetInt("Level10_Stars");
    //PlayerPrefs.GetInt("Level11_Stars");
    //PlayerPrefs.GetInt("Level12_Stars");
    //PlayerPrefs.GetInt("Level13_Stars");
    //PlayerPrefs.GetInt("Level14_Stars");
    //PlayerPrefs.GetInt("Level15_Stars");

}
