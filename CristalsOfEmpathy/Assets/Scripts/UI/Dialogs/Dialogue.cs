#region Using Directives

using System;
using UnityEngine;

#endregion

[Serializable]
public class Dialogue
{
    #region Member Variable

    public ScriptableProfilePNJ profilePnj;
    public Dialogue.Emotion emotion;
    public bool isAnswerNeeded;
    public int nextTextId;

    [TextArea(3, 10)] public string sentence;

    public enum Emotion
    {
        HAPPY,
        SAD,
        CONFUSE,
        ANGRY,
        FEAR
    }

    public Sprite GetSpriteWithEmotion()
    {
        switch (emotion)
        {
            case Emotion.HAPPY:
                return profilePnj.happyFace;
            case Emotion.SAD:
                return profilePnj.sadFace;
            case Emotion.CONFUSE:
                return profilePnj.confuseFace;
            case Emotion.ANGRY:
                return profilePnj.angryFace;
            case Emotion.FEAR:
                return profilePnj.fearFace;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    #endregion
}