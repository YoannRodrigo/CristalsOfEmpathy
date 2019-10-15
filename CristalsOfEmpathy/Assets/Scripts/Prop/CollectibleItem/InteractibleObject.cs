#region Using Directives
using UnityEngine;
#endregion

public class InteractibleObject : InteractibleItem
{
    #region Member Variables
    #endregion
    
    #region Methods
    protected override void OnTouch()
    {
        Debug.Log(canBeTouch ? "Touch" : "Too far");
    }
    #endregion
}
