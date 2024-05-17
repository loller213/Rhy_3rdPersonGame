using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MapManager : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public Camera charCamera;
    public Camera mapCamera;
    public GameObject mapScreen;
    public bool isMapShown;
    private Vector3 defaultPosition;
    private Quaternion defaultRotation;
    private Vector3 defaultScale;
    
    private float zoomSpeed = 5f;
    
    private Vector2 xBounds = new Vector2(-6.28f, 10.2f);
    private Vector2 zBounds = new Vector2(-11.6f, 16.2f);
    private Vector2 yBounds = new Vector2(10.4f, 45.2f);
    
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
            var h = Input.GetAxis("Mouse X");
            var v = Input.GetAxis("Mouse Y");
            
            var move = new Vector3(h, v, 0);
            move = mapCamera.transform.rotation * move;
            
            var newPosition = mapCamera.transform.position - move;
            
            newPosition.x = Mathf.Clamp(newPosition.x, xBounds.x, xBounds.y);
            newPosition.z = Mathf.Clamp(newPosition.z, zBounds.x, zBounds.y);
            
            mapCamera.transform.position = newPosition;
        }
        else
        {
            var zoom = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            var newZoomPosition = mapCamera.transform.position + mapCamera.transform.forward * zoom;
            newZoomPosition.y = Mathf.Clamp(newZoomPosition.y, yBounds.x, yBounds.y);
            mapCamera.transform.position = newZoomPosition;
        }
    }
}