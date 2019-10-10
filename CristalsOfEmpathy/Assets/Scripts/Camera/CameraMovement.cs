#region Using Directives
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#endregion

public class CameraMovement : MonoBehaviour
{
    // x = 0 / y = 25 / z = -10
    #region Member Variables
    public Transform _target;
    public float _smoothSpeed = 0.125f;
    public Vector3 _offset;

    #endregion

    #region Methods
    void Start()
    {
        _offset = new Vector3(0, 25, -10);
    }
    void FixedUpdate()
    {

        Vector3 desiredPosition = _target.position + _offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(_target);
    }

    #endregion
}
