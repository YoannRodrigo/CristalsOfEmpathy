#region Using Directives

using UnityEngine;
#endregion

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    #region Member Variables

    private Joystick joystick;
    private Rigidbody rb;
    
    #endregion

    #region Methods

    private void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(joystick)
        {
            rb.velocity = new Vector3(joystick.Horizontal * 5f, rb.velocity.y, joystick.Vertical * 5f);
        }
    }

    #endregion
}