public class InteractibleDante : InteractiblePnj
{
    public ScriptablePNJ dialogueGuardian;
    public InteractiblePnj muein;
    public InteractiblePnj nuien;
    
    public override void Start()
    {
        base.Start();
        if(EndGameManager.instance.inFearBranch)
        {
            dialogue = dialogueGuardian;
            Speak();
            muein.GetComponent<NonPlayableCharacter>().enabled = false;
            nuien.GetComponent<NonPlayableCharacter>().enabled = false;
        }
    }

    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        if (EndGameManager.instance.inFearBranch)
        {
            LevelChanger.instance.ChangeToLevelWithFade("GuardianScreen");
        }
    }
}
