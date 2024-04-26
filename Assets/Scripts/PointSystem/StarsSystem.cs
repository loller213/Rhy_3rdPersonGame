using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarsSystem : MonoBehaviour
{
    private static StarsSystem _instance;
    public static StarsSystem Instance => _instance;

    public bool deleteAllData = false;

    private Scene scene;
    [SerializeField] private string sceneName;

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
        if (deleteAllData)
        {
            DeleteData();
        }

        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;

    }

    private void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void InitializeStars()
    {
        PlayerPrefs.SetInt("Level1_Stars", 0);
        PlayerPrefs.SetInt("Level2_Stars", 0);
        PlayerPrefs.SetInt("Level3_Stars", 0);
        PlayerPrefs.SetInt("Level4_Stars", 0);
        PlayerPrefs.SetInt("Level5_Stars", 0);
        PlayerPrefs.SetInt("Level6_Stars", 0);
        PlayerPrefs.SetInt("Level7_Stars", 0);
        PlayerPrefs.SetInt("Level8_Stars", 0);
        PlayerPrefs.SetInt("Level9_Stars", 0);
        PlayerPrefs.SetInt("Level10_Stars", 0);
        PlayerPrefs.SetInt("Level11_Stars", 0);
        PlayerPrefs.SetInt("Level12_Stars", 0);
        PlayerPrefs.SetInt("Level13_Stars", 0);
        PlayerPrefs.SetInt("Level14_Stars", 0);
        PlayerPrefs.SetInt("Level15_Stars", 0);
    }

    #region StarAssignment
    public void StarAssignment(int value)
    {

        switch (sceneName)
        {
            case "Level1":
                // Code for Level1
                PlayerPrefs.SetInt("Level1_Stars", value);
                break;

            case "Level2":
                // Code for Level2
                PlayerPrefs.SetInt("Level2_Stars", value);
                break;

            case "Level3":
                // Code for Level3
                PlayerPrefs.SetInt("Level3_Stars", value);
                break;

            case "Level4":
                // Code for Level4
                PlayerPrefs.SetInt("Level4_Stars", value);
                break;

            case "Level5":
                // Code for Level5
                PlayerPrefs.SetInt("Level5_Stars", value);
                break;

            case "Level6":
                // Code for Level6
                PlayerPrefs.SetInt("Level6_Stars", value);
                break;

            case "Level7":
                // Code for Level7
                PlayerPrefs.SetInt("Level7_Stars", value);
                break;

            case "Level8":
                // Code for Level8
                PlayerPrefs.SetInt("Level8_Stars", value);
                break;

            case "Level9":
                // Code for Level9
                PlayerPrefs.SetInt("Level9_Stars", value);
                break;

            case "Level10":
                // Code for Level10
                PlayerPrefs.SetInt("Level10_Stars", value);
                break;

            case "Level11":
                // Code for Level11
                PlayerPrefs.SetInt("Level11_Stars", value);
                break;

            case "Level12":
                // Code for Level12
                PlayerPrefs.SetInt("Level12_Stars", value);
                break;

            case "Level13":
                // Code for Level13
                PlayerPrefs.SetInt("Level13_Stars", value);
                break;

            case "Level14":
                // Code for Level14
                PlayerPrefs.SetInt("Level14_Stars", value);
                break;

            case "Level15":
                // Code for Level15
                PlayerPrefs.SetInt("Level15_Stars", value);
                break;

            default:

                break;

        }

    }
    #endregion
}
