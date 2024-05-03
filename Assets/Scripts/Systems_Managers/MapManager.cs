using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI levelText;
    public GameObject mapScreen;
    public bool isShown;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        levelText.text = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.M)) return;
        
        if (PauseManager.Instance.isPaused)
        {
            PauseManager.Instance.pauseScreen.SetActive(false);
            PauseManager.Instance.isPaused = false;
        }
        
        switch (isShown)
        {
            case true when Input.GetKeyDown(KeyCode.M):
                mapScreen.SetActive(false);
                isShown = false;
                break;
            case false when Input.GetKeyDown(KeyCode.M):
                mapScreen.SetActive(true);
                isShown = true;
                break;
        }
    }
}