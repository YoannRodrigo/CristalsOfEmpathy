#region Using Directives

using System;
using UnityEngine;

#endregion

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    #region Member Variables

    private const float MAX_SPEED = 5f;
    public float rotationLerpSpeed = 10f;
    private Quaternion orientation;
    private SingleJoystick joystick;
    private Rigidbody rb;
    private Animator animator;
    [HideInInspector] public FocusLook look;
    private static readonly int speed = Animator.StringToHash("Speed");
    private bool frozen;
    public void Freeze(){frozen = true;}
    public void UnFreeze(){frozen = false;}
    #endregion

    #region Methods

    private void Start()
    {
        joystick = InterfaceManager.instance.joystick;
        rb = GetComponent<Rigidbody>();
        animator = Instantiate(GeneralGameManager.instance.playerCharacterPrefabs[GeneralGameManager.instance.GetPlayerChoice()],
            transform).GetComponentInChildren<Animator>();

        look = GetComponentInChildren<FocusLook>();
    }

    public void OrientTowards(Vector3 position)
    {
        transform.forward = (position - transform.position).normalized;
        //Vector3 dir = (position - transform.position).normalized;
        //orientation = Quaternion.Slerp(orientation, Quaternion.LookRotation(new Vector3(dir.x, 0f, dir.y)), rotationLerpSpeed * Time.deltaTime);
    }


    public void Move(Vector3 direction)
    {
        direction = Vector3.ClampMagnitude(direction, 1f);
        rb.velocity = new Vector3(direction.x * MAX_SPEED, rb.velocity.y, direction.y * MAX_SPEED);
        orientation = Quaternion.Slerp(orientation, Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.y)), rotationLerpSpeed * Time.deltaTime);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, orientation, rotationLerpSpeed * Time.deltaTime);

        if(frozen) return;

        Vector3 moveVector = new Vector3();
        if(Application.isEditor) moveVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        else
        {
            moveVector = joystick.GetInputDirection();
            if (!joystick.gameObject.activeSelf) rb.velocity = Vector3.zero;
        }

        if (Math.Abs(moveVector.magnitude) > 0.0f)
        {
            Move(moveVector);
        }
    }

    private void FixedUpdate()
    {
        Vector3 velocityOnGround = Vector3.Scale(rb.velocity, new Vector3(1, 0, 1));
		if(animator != null)
			animator.SetFloat(speed, velocityOnGround.magnitude/MAX_SPEED);
    }

    #endregion
}