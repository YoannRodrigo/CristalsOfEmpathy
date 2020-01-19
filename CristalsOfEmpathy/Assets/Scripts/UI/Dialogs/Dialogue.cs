﻿#region Using Directives

using System;
using UnityEngine;

#endregion

[Serializable]
public class Dialogue
{
    #region Member Variables

    public string pnjName;
    public bool isAnswerNeeded;
    public int nextTextId;

    [TextArea(3, 10)] public string sentence;

    #endregion
}