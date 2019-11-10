#region Using Directives

using System;
using UnityEngine;
#endregion

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    #region Member Variables

    private const float WALKING_SPEED_MAX = 3f;
    private const float ROTATION_SPEED = 2f;
    private SingleJoystick joystick;
    private Rigidbody rb;
    private Animator animator;
    private static readonly int isPlayerRunning = Animator.StringToHash("isPlayerRunning");
    private static readonly int isPlayerWalking = Animator.StringToHash("isPlayerWalking");
    private Vector3 joystickMovement;
    
    #endregion

    #region Methods

    private void Start()
    {
        joystick = FindObjectOfType<SingleJoystick>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (joystick)
        {
            joystickMovement = joystick.GetInputDirection();
            if (Math.Abs(joystickMovement.magnitude) > 0.0f)
            {
                Vector3 newLookDirection = new Vector3(joystickMovement.x, 0, joystickMovement.y);
                transform.rotation = Quaternion.LookRotation(newLookDirection);
            }

            rb.velocity = new Vector3(joystickMovement.x * 5f, rb.velocity.y, joystickMovement.y * 5f);
        }

        if (!joystick.gameObject.activeSelf)
        {
            rb.velocity = Vector3.zero;
        }

        Vector3 velocityOnGround = Vector3.Scale(rb.velocity, new Vector3(1, 0, 1));
        if (Math.Abs(velocityOnGround.magnitude) <= 0.2f)
        {
            animator.SetBool(isPlayerRunning, false);
            animator.SetBool(isPlayerWalking, false);
        }
        else
        {
            Quaternion velocityAngle = Quaternion.Euler(0, Vector3.SignedAngle(transform.forward, velocityOnGround, Vector3.up), 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, velocityAngle, ROTATION_SPEED * Time.deltaTime);
            if (Math.Abs(velocityOnGround.magnitude) < WALKING_SPEED_MAX)
            {
                animator.SetBool(isPlayerRunning, false);
                animator.SetBool(isPlayerWalking, true);
            }
            else
            {
                animator.SetBool(isPlayerRunning, true);
                animator.SetBool(isPlayerWalking, false);
            }
        }
    }

    #endregion
}