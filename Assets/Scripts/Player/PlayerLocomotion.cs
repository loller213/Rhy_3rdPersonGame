using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{

    InputManager inputManager;

    Vector3 moveDirection;
    Transform cameraObject;

    Rigidbody playerRB;

    [Header("Movement Speed")]
    public float walkingSpeed = 1.5f;
    public float runningSpeed = 4;
    public float sprintingSpeed = 5;
    public float rotationSpeed = 15;

    public bool isSprinting;
    public bool isWalking;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRB = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    private void Start()
    {
        isWalking = false;
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;

        //if (Input.GetKeyDown(KeyCode.LeftControl) && isWalking)
        //{
        //    isWalking = false;
        //}
        //else if (Input.GetKeyDown(KeyCode.LeftControl) && !isWalking)
        //{
        //    isWalking = true;
        //}

        //if (isWalking)
        //{
        //    inputManager.moveAmount = 0.5f;
        //    moveDirection = moveDirection * walkingSpeed;
        //}
        //else
        //{
        //    moveDirection = moveDirection * runningSpeed;
        //}

        if (isSprinting)
        {
            moveDirection = moveDirection * sprintingSpeed;
        }
        else
        {
            if (inputManager.moveAmount >= 0.5f)
            {
                moveDirection = moveDirection * runningSpeed;
            }
            else
            {
                moveDirection = moveDirection * walkingSpeed;
            }
        }

        Vector3 movementVelocity = moveDirection;
        playerRB.velocity = movementVelocity;

    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;

        targetDirection = cameraObject.forward * inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }

}
