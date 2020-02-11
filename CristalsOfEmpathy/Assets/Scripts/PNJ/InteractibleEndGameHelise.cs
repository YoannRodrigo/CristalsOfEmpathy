#region Using Directives

#endregion

using System;

public class InteractibleEndGameHelise : InteractiblePnj
{
    #region Methods

    public override void OnDialogEnded()
    {
        switch (emotion)
        {
            case BarPointsHandler.Emotions.LOVE:
                LevelChanger.instance.ChangeToLevelWithFade(LOVE_ENIGMA_SCENE_ID);
                break;
            case BarPointsHandler.Emotions.FEAR:
                LevelChanger.instance.ChangeToLevelWithFade(FEAR_ENIGMA_SCENE_ID);
                break;
            case BarPointsHandler.Emotions.CURIOSITY:
                LevelChanger.instance.ChangeToLevelWithFade(CURIOSITY_ENIGMA_SCENE_ID);
                break;
            case BarPointsHandler.Emotions.AVERSION:
                LevelChanger.instance.ChangeToLevelWithFade(AVERSION_ENIGMA_SCENE_ID);
                break;
            case BarPointsHandler.Emotions.NONE:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    #endregion

    public void SetEmotion(BarPointsHandler.Emotions emotion)
    {
        this.emotion = emotion;
    }
    
    #region Member Variables

    private BarPointsHandler.Emotions emotion;
    private const int LOVE_ENIGMA_SCENE_ID = 4;
    private const int AVERSION_ENIGMA_SCENE_ID = 5;
    private const int FEAR_ENIGMA_SCENE_ID = 6;
    private const int CURIOSITY_ENIGMA_SCENE_ID = 7;


    #endregion
}