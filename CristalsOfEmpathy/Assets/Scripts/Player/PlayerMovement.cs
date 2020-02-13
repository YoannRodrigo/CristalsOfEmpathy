#region Using Directives

using System;
using UnityEngine;

#endregion

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    #region Member Variables

    private const float MAX_SPEED = 5f;
    public float rotation_speed;
    private SingleJoystick joystick;
    private Rigidbody rb;
    private Animator animator;
    private Vector3 joystickMovement;
    private static readonly int speed = Animator.StringToHash("Speed");

    #endregion

    #region Methods

    private void Start()
    {
        joystick = InterfaceManager.instance.joystick;
        rb = GetComponent<Rigidbody>();
        animator = Instantiate(GeneralGameManager.instance.playerCharacterPrefabs[GeneralGameManager.instance.GetPlayerChoice()],
            transform).GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (joystick)
        {
            joystickMovement = joystick.GetInputDirection();
            if(Application.isEditor)
            {
                joystickMovement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0);
            }
            if (Math.Abs(joystickMovement.magnitude) > 0.0f)
            {
                Vector3 newLookDirection = new Vector3(joystickMovement.x, 0, joystickMovement.y);
                transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(newLookDirection),rotation_speed*Time.deltaTime);
            }

            rb.velocity = new Vector3(joystickMovement.x * MAX_SPEED, rb.velocity.y, joystickMovement.y * MAX_SPEED);
        }

        if (!joystick.gameObject.activeSelf) rb.velocity = Vector3.zero;

        Vector3 velocityOnGround = Vector3.Scale(rb.velocity, new Vector3(1, 0, 1));

		if(animator != null)
			animator.SetFloat(speed, velocityOnGround.magnitude/MAX_SPEED);
    }

    #endregion
}