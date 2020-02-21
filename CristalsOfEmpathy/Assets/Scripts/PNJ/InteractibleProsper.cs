public class InteractibleProsper : InteractiblePnj
{
    public ScriptablePNJ dialogueAmour;
    public ScriptablePNJ dialogueMage;

    public override void Start()
    {
        base.Start();
        if (EndGameManager.instance.inLoveBranch)
        {
            dialogue = !EndGameManager.instance.hasPlayerMeetMages ? dialogueAmour : dialogueMage;
        }
    }

    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        if (EndGameManager.instance.inLoveBranch && EndGameManager.instance.hasPlayerMeetMages)
        {
            LevelChanger.instance.ChangeToLevelWithFade("GuardianScene");
        }
    }
}