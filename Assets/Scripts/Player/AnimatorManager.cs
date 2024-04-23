using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{

    Animator animator;
    int horizontal, vertical;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    public void PlayTargetAnimation(string targetAnimation, bool isInteracting)
    {
        animator.SetBool("isInteracting", isInteracting);
        animator.Play(targetAnimation);
    }

    public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement, bool isSprinting, bool isWalking)
    {

        //Float Snapping
        float snapHorizontal, snapvertical;

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
            snapvertical = 0.5f;
        }
        else if (verticalMovement > 0.55f)
        {
            snapvertical = 1;
        }
        else if (verticalMovement < 0 && verticalMovement > -0.55f)
        {
            snapvertical = -0.5f;
        }
        else if (verticalMovement < -0.55f)
        {
            snapvertical = -1;
        }
        else
        {
            snapvertical = 0;
        }
        #endregion


        if (isWalking)
        {
            snapHorizontal = horizontalMovement;
            snapvertical = 0.5f;
        }
        if (isSprinting)
        {
            snapHorizontal = horizontalMovement;
            snapvertical = 2;
        }

        animator.SetFloat(horizontal, snapHorizontal, 0.1f, Time.deltaTime);
        animator.SetFloat(vertical, snapvertical, 0.1f, Time.deltaTime);
    }


}
