#region Using Directives
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

public class GyroscopeCameraRotation : BasicCameraRotation
{
    #region Member Variables
    private float x;
    private float y;

    public bool gyroEnabled = false;
    readonly float sensitivity = 50.0f;

    private Gyroscope gyro;
    #endregion

    #region Methods
    private void Start()
    {
        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }

        return false;
    }
    private void Update()
    {
        if (gyroEnabled)
        {
            GyroRotation();
        }
    }
    private void GyroRotation()
    {
        x = Input.gyro.rotationRate.x;
        y = Input.gyro.rotationRate.y;

        float xFiltered = FilterGyroValues(x);
        RotateUpDown(xFiltered * sensitivity);

        float yFiltered = FilterGyroValues(y);
        RotateRightLeft(yFiltered * sensitivity);
    }

    private float FilterGyroValues(float axis)
    {
        if (axis < -0.1 || axis > 0.1)
        {
            return axis;
        }
        else
        {
            return 0;
        }
    }
    #endregion
}