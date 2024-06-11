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

        if (currentLevelIndex <= 2 && currentLevelIndex >= 0)
        {
            Debug.Log("Level Scene: " + currentLevelIndex + " Theme 1");
            AudioManager.Instance.BGMplay("Theme_1");
        }
        else if (currentLevelIndex <= 7 && currentLevelIndex >= 3)
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
            switch (currentLevelIndex)
            {
                case 18:
                    AudioManager.Instance.BGMplay("RL1");
                    break;
                case 19:
                    AudioManager.Instance.BGMplay("RL2");
                    break;
                case 20:
                    AudioManager.Instance.BGMplay("RL3");
                    break;
                case 21:
                    AudioManager.Instance.BGMplay("RL4");
                    break;
                case 22:
                    AudioManager.Instance.BGMplay("RL5");
                    break;
                case 23:
                    AudioManager.Instance.BGMplay("RL6");
                    break;
                case 24:
                    AudioManager.Instance.BGMplay("RL7");
                    break;
                case 25:
                    AudioManager.Instance.BGMplay("RL8");
                    break;
                case 26:
                    AudioManager.Instance.BGMplay("RL9");
                    break;
                case 27:
                    AudioManager.Instance.BGMplay("RL10");
                    break;
                case 28:
                    AudioManager.Instance.BGMplay("RL11");
                    break;
                case 29:
                    AudioManager.Instance.BGMplay("RL12");
                    break;
                case 30:
                    AudioManager.Instance.BGMplay("RL13");
                    break;
                case 31:
                    AudioManager.Instance.BGMplay("RL14");
                    break;
                case 32:
                    AudioManager.Instance.BGMplay("RL15");
                    break;
                case 33:
                    AudioManager.Instance.BGMplay("RL16");
                    break;
                case 34:
                    AudioManager.Instance.BGMplay("RL17");
                    break;
                case 35:
                    AudioManager.Instance.BGMplay("RL18");
                    break;
                case 36:
                    AudioManager.Instance.BGMplay("RL19");
                    break;
                default:
                    Debug.Log("Can't Find Level Audio for Random");
                    break;
            }
        }
    }
}
