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
    [SerializeField] private int starRequirement;

    [SerializeField] private GameObject sign;

    public int TotalStars{ get => totalStars; private set => totalStars = value;}
    public string[] PrefName { get => prefName; private set => prefName = value; }

    protected virtual void Start()
    {
        CheckModeUnlock();
    }

    private void CheckModeUnlock()
    {

        if (AddAllStars() >= starRequirement)
        {
            sign.SetActive(false);
            modeButton.interactable = true;
        }
        else
        {
            sign.SetActive(true);
            modeButton.interactable = false;
        }
    }

    protected int AddAllStars()
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
