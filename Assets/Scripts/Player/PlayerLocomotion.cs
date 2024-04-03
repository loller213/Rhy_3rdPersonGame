using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    PlayerManager playerManager;
    AnimatorManager animatorManager;
    InputManager inputManager;

    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRB;

    [Header("Falling")]
    public float inAirTimer;
    public float leapingVelocity;
    public float fallingSpeed;
    public float rayCastHeightOffSet = 0.2f;
    public LayerMask groundLayer;
    public float maxDistance = 1;

    [Header("Movement Speed")]
    public float walkingSpeed = 1.5f;
    public float runningSpeed = 4;
    public float sprintingSpeed = 5;
    public float rotationSpeed = 15;

    [Header("Movement States")]
    public bool isSprinting;
    public bool isWalking;
    public bool isGrounded;

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        animatorManager = GetComponent<AnimatorManager>();
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

        HandleFallingAndLanding();

        if (playerManager.isInteracting)
        {
            return;
        }
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
        else if (isWalking)
        {
            moveDirection = moveDirection * walkingSpeed;
        }
        else if (inputManager.moveAmount >= 0.5f)
        {
            moveDirection = moveDirection * runningSpeed;
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

    private void HandleFallingAndLanding()
    {
        RaycastHit hit;
        Vector3 rayCastOrigin = transform.position;
        rayCastOrigin.y = rayCastOrigin.y + rayCastHeightOffSet;

        if (!isGrounded)
        {
            if (!playerManager.isInteracting)
            {
                animatorManager.PlayTargetAnimation("Falling", true);
            }

            inAirTimer = inAirTimer + Time.deltaTime;
            playerRB.AddForce(transform.forward * leapingVelocity);
            playerRB.AddForce(-Vector3.up * fallingSpeed * inAirTimer);

        }

        if (Physics.SphereCast(rayCastOrigin, 0.2f, -Vector3.up, out hit, maxDistance, groundLayer))
        {
            if (!isGrounded && !playerManager.isInteracting)
            {
                animatorManager.PlayTargetAnimation("Landing", true);
            }

            inAirTimer = 0;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }

}
