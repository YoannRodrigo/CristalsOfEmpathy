#region Using Directives

using System;
using UnityEngine;

#endregion

[Serializable]
public class PlayerAnswer
{
    #region Member Variables

    [TextArea(3, 10)] public string text;

    public int nextTextId;
    public BarPointsHandler.Emotions emotion;
    public int influence;

    #endregion
}