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
        if(Instance == null){Instance = this;}
        else { Destroy(this);}

        if (AudioManager == null)
            AudioManager = AudioManager.Instance;
    }
   
    private void PlayBGMPerScene(string audioName)
    {
        AudioManager.BGMplay(audioName);
    }

    public void GetSceneAudio()
    {
        AudioManager.BGMstop();
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Level Scene: " + currentLevelIndex);
        if (currentLevelIndex <= 7 && currentLevelIndex >= 3)
        {
            PlayBGMPerScene("Easy_BGM");
        }
        else if (currentLevelIndex <= 12 && currentLevelIndex >= 8)
        {
            PlayBGMPerScene("Medium_BGM");
        }
        else if (currentLevelIndex >= 17 && currentLevelIndex >= 13)
        {
            PlayBGMPerScene("Hard_BGM");
        }
        else
        {
            PlayBGMPerScene("Theme_1");
        }
    }
}
