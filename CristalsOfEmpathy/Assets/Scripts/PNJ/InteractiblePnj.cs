#region Using Directives

using UnityEngine;

#endregion

public class InteractiblePnj : InteractibleItem
{
    #region Member Variables

    #endregion
    
    #region Methods
    protected override void OnTouch()
    {
        if (canBeTouch)
        {
            Debug.Log("Interacting with a PNJ...");
        }
    }
    #endregion
}
