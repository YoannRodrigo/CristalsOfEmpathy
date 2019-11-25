#region Using Directives

using System.Collections.Generic;
#endregion

[System.Serializable]
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
    #endregion
}
