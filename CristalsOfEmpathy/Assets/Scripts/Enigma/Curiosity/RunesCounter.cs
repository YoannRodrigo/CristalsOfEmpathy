#region Using Directives
using UnityEngine;
#endregion

public class RunesCounter : MonoBehaviour
{
    #region Member Variables
    public int runesCount;
    #endregion

    #region Methods
    private void Awake()
    {
        runesCount = 0;
    }
    #endregion
}
