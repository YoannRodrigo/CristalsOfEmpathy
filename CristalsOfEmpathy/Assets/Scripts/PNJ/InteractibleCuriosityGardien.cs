public class InteractibleCuriosityGardien : InteractiblePnj
{
    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        if(!EndGameManager.instance.inCuriosityBranch)
        {
            EndGameManager.instance.inCuriosityBranch = true;
        }
        else
        {
            DialogueManager.instance.gameObject.SetActive(false);
            LevelChanger.instance.ChangeToLevelWithFade("CuriosityEnigma");
        }
    }
}
