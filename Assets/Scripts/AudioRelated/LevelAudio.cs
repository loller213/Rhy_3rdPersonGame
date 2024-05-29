using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LevelAudio : MonoBehaviour
{
    public static LevelAudio Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        AudioManager.Instance.BGMstop();
        GetSceneAudio();
    }

    private void GetSceneAudio()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentLevelIndex <= 7 && currentLevelIndex >= 3)
        {
            Debug.Log("Level Scene: " + currentLevelIndex + " Easy BGM");
            AudioManager.Instance.BGMplay("Easy");
        }
        else if (currentLevelIndex <= 12 && currentLevelIndex >= 8)
        {
            Debug.Log("Level Scene: " + currentLevelIndex + " Medium BGM");
            AudioManager.Instance.BGMplay("Medium");
        }
        else if (currentLevelIndex >= 17 && currentLevelIndex >= 13)
        {
            AudioManager.Instance.BGMplay("Hard");
            Debug.Log("Level Scene: " + currentLevelIndex + " Hard BGM");
        }
        else
        {
            Debug.Log("Level Scene: " + currentLevelIndex + " Theme 1");
            AudioManager.Instance.BGMplay("Theme_1");
        }
    }
}
