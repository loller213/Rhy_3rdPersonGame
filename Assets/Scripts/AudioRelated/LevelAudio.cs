using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LevelAudio : MonoBehaviour
{
    public static LevelAudio Instance;
    [SerializeField] private AudioManager AudioManager;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        LoadAudio();
    }

    public void LoadAudio()
    {
        AudioManager.BGMstop();
        GetSceneAudio();
    }

    private void GetSceneAudio()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentLevelIndex <= 7 && currentLevelIndex >= 3)
        {
            Debug.Log("Level Scene: " + currentLevelIndex + " Easy BGM");
            AudioManager.BGMplay("Easy");
        }
        else if (currentLevelIndex <= 12 && currentLevelIndex >= 8)
        {
            Debug.Log("Level Scene: " + currentLevelIndex + " Medium BGM");
            AudioManager.BGMplay("Medium");
        }
        /*
        else if (currentLevelIndex >= 17 && currentLevelIndex >= 13)
        {
            AudioManager.BGMplay(audioName);
        }*/
        else
        {
            AudioManager.BGMplay("Theme_1");
        }
    }
}
