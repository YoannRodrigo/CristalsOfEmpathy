#region Using Directives
using UnityEngine;
#endregion

[System.Serializable]
public class Personna
{
    #region Member Variables
    
    public Sprite avatarPortrait;
    public string name;
    [TextArea(3, 10)]
    public string dialogues;
    public char couple;
    
    #endregion
    
    #region Methods
    #endregion
}    
