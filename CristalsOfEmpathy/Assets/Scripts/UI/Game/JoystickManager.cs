#region Using Directives

using UnityEngine;

#endregion

public class JoystickManager : MonoBehaviour
{
    #region Member Variables

    public SingleJoystickTouchController joystick;

    #endregion

    #region Methods

    public SingleJoystickTouchController GetJoystick()
    {
        return joystick;
    }

    #endregion
}