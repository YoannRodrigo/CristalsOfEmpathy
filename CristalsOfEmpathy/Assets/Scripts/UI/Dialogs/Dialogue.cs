#region Using Directives
using UnityEngine;
#endregion

[System.Serializable]
public class Dialogue
{
    #region Member Variables
    public string pnjName;

    [TextArea(3, 10)]
    public string[] sentences;
    #endregion
}
