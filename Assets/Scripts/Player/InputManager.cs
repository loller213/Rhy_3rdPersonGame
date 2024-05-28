using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance => _instance;

    PlayerControls playerControls;
    PlayerLocomotion playerLocomotion;
    AnimatorManager animatorManager;
    MapManager mapManager;

    public Vector2 movementInput;
    public Vector2 cameraInput;

    public float cameraInputX;
    public float cameraInputY;

    public float moveAmount;

    public float verticalInput;
    public float horizontalInput;

    public bool sprint_input;
    public bool walk_input;
    public bool restartLevel_input;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        animatorManager = GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        mapManager = FindObjectOfType<MapManager>();
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

            playerControls.PlayerActions.Sprint.performed += i => sprint_input = true;
            playerControls.PlayerActions.Sprint.canceled += i => sprint_input = false;

            playerControls.PlayerActions.Walk.performed += i => walk_input = true;
            playerControls.PlayerActions.Walk.canceled += i => walk_input = false;

            playerControls.PlayerActions.RestartLevel.performed += i => restartLevel_input = true;
        }

        playerControls.Enable();

    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInput()
    {
        if (mapManager.isMapShown)
        {
            AnimatorManager.Instance.ResetAnimValues();
            return;
        }
        
        HandleMovementInput();
        HandleSprint();
        HandleWalk();
        HandleRestartLevelInput();
    }

    
    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount, playerLocomotion.isSprinting, playerLocomotion.isWalking);

    }

    public void ResetMoveValues()
    {
        verticalInput = 0;
        horizontalInput = 0;
        moveAmount = 0;
    }

    public void EnableRestartSystem()
    {
        playerControls.PlayerActions.RestartLevel.Enable();
    }

    public void DisableRestartSystem()
    {
        playerControls.PlayerActions.RestartLevel.Disable();
    }

    private void HandleWalk()
    {
        if (walk_input && moveAmount > 0.5f)
        {
            playerLocomotion.isWalking = true;
        }
        else
        {
            playerLocomotion.isWalking = false;
        }
    }

    private void HandleSprint()
    {
        if (sprint_input && moveAmount > 0.5f)
        {
            playerLocomotion.isSprinting = true;
        }
        else
        {
            playerLocomotion.isSprinting = false;
        }
    }

    private void HandleRestartLevelInput()
    {
        if (restartLevel_input)
        {
            if (!MapManager.Instance.GetMapState())
            {
                restartLevel_input = false;
                SceneManagerScript.Instance.RestartScene();
            }
            else if (MapManager.Instance.GetMapState())
            {
                restartLevel_input = false;
            }
        }
    }

}
