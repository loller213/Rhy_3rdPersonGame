using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{

    private static AnimatorManager _instance;
    public static AnimatorManager Instance => _instance;

    Animator animator;
    int horizontal, vertical;

    //Float Snapping
    float snapHorizontal, snapVertical;

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

        animator = GetComponent<Animator>();
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    public void PlayTargetAnimation(string targetAnimation, bool isInteracting)
    {
        animator.SetBool("isInteracting", isInteracting);
        animator.Play(targetAnimation);
    }

    //, bool isMapShown
    public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement, bool isSprinting, bool isWalking)
    {

        #region Snapped Horizontal
        if (horizontalMovement > 0 && horizontalMovement < 0.55f)
        {
            snapHorizontal = 0.5f;
        }
        else if (horizontalMovement > 0.55f)
        {
            snapHorizontal = 1;
        }
        else if (horizontalMovement < 0 && horizontalMovement > -0.55f)
        {
            snapHorizontal = -0.5f;
        }
        else if (horizontalMovement < -0.55f)
        {
            snapHorizontal = -1;
        }
        else
        {
            snapHorizontal = 0;
        }
        #endregion
        #region Snapped Vertical
        if (verticalMovement > 0 && verticalMovement < 0.55f)
        {
            snapVertical = 0.5f;
        }
        else if (verticalMovement > 0.55f)
        {
            snapVertical = 1;
        }
        else if (verticalMovement < 0 && verticalMovement > -0.55f)
        {
            snapVertical = -0.5f;
        }
        else if (verticalMovement < -0.55f)
        {
            snapVertical = -1;
        }
        else
        {
            snapVertical = 0;
        }
        #endregion

        //if (isMapShown)
        //{
        //    snapVertical = 0;
        //    snapVertical = 0;
        //}
        if (isWalking)
        {
            snapHorizontal = horizontalMovement;
            snapVertical = 0.5f;
        }
        if (isSprinting)
        {
            snapHorizontal = horizontalMovement;
            snapVertical = 2;
        }

        animator.SetFloat(horizontal, snapHorizontal, 0.1f, Time.deltaTime);
        animator.SetFloat(vertical, snapVertical, 0.1f, Time.deltaTime);
    }

    public void ResetAnimValues()
    {
        snapVertical = 0;
        snapVertical = 0;
        animator.SetFloat(horizontal, snapHorizontal, 0.1f, Time.deltaTime);
        animator.SetFloat(vertical, snapVertical, 0.1f, Time.deltaTime);
    }

}
