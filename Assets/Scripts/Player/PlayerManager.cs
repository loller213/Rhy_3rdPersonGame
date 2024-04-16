using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    Animator animator;
    InputManager inputManager;
    CameraManager cameraManager;
    PlayerLocomotion playerLocomotion;

    public bool isInteracting;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        inputManager = GetComponent<InputManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        if (!PointSystem.Instance.levelState())
        {
            inputManager.HandleAllInput();
        }

    }

    private void FixedUpdate()
    {
        if (!PointSystem.Instance.levelState())
        {
            playerLocomotion.HandleAllMovement();
        }
    }

    private void LateUpdate()
    {
        if (!PointSystem.Instance.levelState())
        {
            cameraManager.HandleAllCameraMovement();
            isInteracting = animator.GetBool("isInteracting");
        }

    }
}
