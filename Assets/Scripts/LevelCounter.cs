using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCounter : MonoBehaviour
{
    public static LevelCounter Instance { get; private set; }

    public int playerLevel = 1; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    public void SetPlayerLevel(int level)
    {
        playerLevel = level;
    }

    public int GetPlayerLevel()
    {
        return playerLevel;
    }
}
