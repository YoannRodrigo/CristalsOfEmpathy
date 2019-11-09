#region Using Directives
using UnityEngine;
#endregion

[System.Serializable]
public class PlayerAnswers
{
    #region Member Variables

    public int nextTextId1, nextTextId2, nextTextId3, nextTextId4;
    [TextArea(3, 10)] 
    public string text1, text2, text3, text4;
    #endregion
}
