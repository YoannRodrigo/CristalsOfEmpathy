#region Using Directives

using System;
using UnityEngine;

#endregion

public class BarPointsHandler : MonoBehaviour
{
    #region Member Variables

    private static BarPointsHandler _instance;

    private static int _loveBarPoints;
    private static int _fearBarPoints;
    private static int _curiosityBarPoints;
    private static int _aversionBarPoints;

    public enum Emotions
    {
        LOVE,
        FEAR,
        CURIOSITY,
        AVERSION,
        NONE
    }


    #endregion

    #region Methods

    public int LoveBarPoints
    {
        get => _loveBarPoints;
        set => _loveBarPoints = value;
    }

    public int FearBarPoints
    {
        get => _fearBarPoints;
        set => _fearBarPoints = value;
    }

    public int CuriosityBarPoints
    {
        get => _curiosityBarPoints;
        set => _curiosityBarPoints = value;
    }

    public int AversionBarPoints
    {
        get => _aversionBarPoints;
        set => _aversionBarPoints = value;
    }

    public BarPointsHandler GetInstance()
    {
        return _instance;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
        {
            _instance = this;
        }
    }

    public static void UpdateEmotionPoints(Emotions emotion, int influence)
    {
        switch (emotion)
        {
            case Emotions.LOVE:
                _loveBarPoints += influence;
                if (EmotionBarReachValues(_loveBarPoints))
                {
                    EndGameManager.instance.SpawnHelise(Emotions.LOVE);
                }
                break;
            case Emotions.FEAR:
                _fearBarPoints += influence;
                if (EmotionBarReachValues(_fearBarPoints))
                {
                    EndGameManager.instance.SpawnHelise(Emotions.FEAR);
                }
                break;
            case Emotions.AVERSION:
                _aversionBarPoints += influence;
                if (EmotionBarReachValues(_aversionBarPoints))
                {
                    EndGameManager.instance.SpawnHelise(Emotions.AVERSION);
                }
                break;
            case Emotions.CURIOSITY:
                _curiosityBarPoints += influence;
                if (EmotionBarReachValues(_curiosityBarPoints))
                {
                    EndGameManager.instance.SpawnHelise(Emotions.CURIOSITY);
                }
                break;
            case Emotions.NONE:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(emotion), emotion, null);
        }
    }

    private static bool EmotionBarReachValues(int emotionBar)
    {
        return emotionBar > 60;
    }
    #endregion
}