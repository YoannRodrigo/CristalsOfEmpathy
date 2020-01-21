#region Using Directives

using System;
using System.Collections.Generic;

#endregion

[Serializable]
public class PlayerAnswers
{
    #region Member Variables

    public List<PlayerAnswer> playerAnswers = new List<PlayerAnswer>(4);

    #endregion

    #region Methods

    public string GetText(int id)
    {
        return playerAnswers[id].text;
    }

    public int GetNextId(int id)
    {
        return playerAnswers[id].nextTextId;
    }

    public BarPointsHandler.Emotions GetEmotion(int id)
    {
        return playerAnswers[id].emotion;
    }

    public int GetEmotionInfluence(int id)
    {
        return playerAnswers[id].influence;
    }

    #endregion
}