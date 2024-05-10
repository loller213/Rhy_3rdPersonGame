using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MapManager : MonoBehaviour
{
    /*public static MapManager Instance { get; private set; }

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
    }*/
    
    public TextMeshProUGUI levelText;
    public Camera charCamera;
    public Camera mapCamera;
    public GameObject mapScreen;
    public bool isMapShown;
    public float rotationSpeed = 1f;
    public float zoomSpeed = 1f;
    public float moveSpeed = 1f;
    private Vector3 defaultPosition;
    private Quaternion defaultRotation;
    private Vector3 defaultScale;
    
    private void Start()
    {
        levelText.text = SceneManager.GetActiveScene().name;
        charCamera.enabled = true;
        mapCamera.enabled = false;
        mapScreen.SetActive(false);
        isMapShown = false;
        
        defaultPosition = mapCamera.transform.position;
        defaultRotation = mapCamera.transform.rotation;
        defaultScale = mapCamera.transform.localScale;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            charCamera.enabled = !charCamera.enabled;
            mapCamera.enabled = !mapCamera.enabled;
            mapScreen.SetActive(mapCamera.enabled);
            isMapShown = mapCamera.enabled;
        }

        if (isMapShown)
        {
            HandleMouseInput();
        }

        if (!isMapShown || Input.GetKeyDown(KeyCode.R))
        {
            mapCamera.transform.position = defaultPosition;
            mapCamera.transform.rotation = defaultRotation;
            mapCamera.transform.localScale = defaultScale;
        }
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButton(1))
        {
            var rotation = Input.GetAxis("Mouse X") * rotationSpeed;
            mapCamera.transform.Rotate(0, 0, rotation);
        }

        if (!Input.GetMouseButton(2))
        {
            var zoom = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            mapCamera.transform.Translate(0, 0, zoom);
        }
        
        if (Input.GetMouseButton(2))
        {
            var h = rotationSpeed * Input.GetAxis("Mouse X") * moveSpeed;
            var v = rotationSpeed * Input.GetAxis("Mouse Y") * moveSpeed;
            
            var move = new Vector3(h, v, 0);
            
            move = mapCamera.transform.rotation * move;
            
            mapCamera.transform.position -= move;
        }
    }
    
    
}