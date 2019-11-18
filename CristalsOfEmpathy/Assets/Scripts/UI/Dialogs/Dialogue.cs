#region Using Directives
using UnityEngine;
#endregion

[System.Serializable]
public class Dialogue
{
    #region Member Variables

    public string pnjName;
    public bool isAnswerNeeded;
    public int nextTextId;
    [TextArea(3, 10)] 
    public string sentence;
    #endregion
}
