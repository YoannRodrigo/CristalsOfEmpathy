public class InteractibleCuriosityGardien : InteractiblePnj
{
    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        if(!EndGameManager.instance.inFearBranch)
        {
        }
        else
        {
            DialogueManager.instance.gameObject.SetActive(false);
            LevelChanger.instance.ChangeToLevelWithFade("CuriosityEnigma");
        }
    }
}
