#region Using Directives
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#endregion

public class PlayerMovement : MonoBehaviour
{
    #region Member Variables
    protected Joystick _joystick;

    #endregion

    #region Methods
    void Start()
    {
        _joystick = FindObjectOfType<Joystick>();
    }

    void Update()
    {
        var _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * 5f, _rigidbody.velocity.y, _joystick.Vertical * 5f);
    }
    #endregion
}
