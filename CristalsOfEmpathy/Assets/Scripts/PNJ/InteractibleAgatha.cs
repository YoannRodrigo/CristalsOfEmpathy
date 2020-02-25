
public class InteractibleAgatha : InteractiblePnj
{
    public ScriptablePNJ dialogueQuest;

    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        GeneralGameManager.instance.hasPlayerMetAgatha = true; 
    }

    public override void Start()
    {
        base.Start();
        if (GeneralGameManager.instance.hasPlayerMetAgatha &&
            GeneralGameManager.instance.hasPlayerMetAlberthus &&
            GeneralGameManager.instance.hasPlayerMetAlice)
        {
            dialogue = dialogueQuest;
        }
        else
        {
            if (GeneralGameManager.instance.hasPlayerMetAlberthus &&
                GeneralGameManager.instance.hasPlayerMetAlice)
            {
                DialogueManager.instance.OverrideAnswers(0,0,4);
            }
        }
    }
}
